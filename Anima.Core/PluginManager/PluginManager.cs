using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.ComponentModel.Composition.Hosting;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;

namespace Anima.Core
{
    public class PluginManager
    {
        System.Timers.Timer TickTimer;

        [ImportMany(typeof(IModule))]
        IEnumerable<IModule> modules;

        List<IModule> EnableModules;
        List<IModule> DisableModules;

        public PluginManager()
        {
            string PluginDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName + @"\Plugins";


            if (!Directory.Exists(PluginDirectory))
            {
                if(!Utilities.IsRunAsAdmin())
                {
                    AnimaCentral.Speak("There's a problem creating the plugin folder.", "Either create your own or run me with Administrative privileges once");
                    // Launch itself as administrator
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.UseShellExecute = true;
                    proc.WorkingDirectory = Environment.CurrentDirectory;
                    proc.FileName = Application.ExecutablePath;
                    proc.Verb = "runas";

                    try
                    {
                        Process.Start(proc);
                    }
                    catch
                    {
                        // The user refused the elevation.
                        // Do nothing and return directly ...
                        return;
                    }

                    Application.Exit();  // Quit itself
                }
                Directory.CreateDirectory(PluginDirectory);
            }

                


            Compose(PluginDirectory);
            SeparateModules();

            foreach (IModule module in EnableModules)
            {
                module.ModuleStart();
            }

            TickTimer = new System.Timers.Timer(Properties.CoreSettings.Default.TickInterval);
            TickTimer.AutoReset = true;
            TickTimer.Elapsed += TickTimer_Elapsed;
            TickTimer.Start();
        }

        private void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TickAll();
        }

        public void EndModules()
        {
            foreach (IModule module in EnableModules)
            {
                module.ModuleEnd();
            }
        }

        public void SortLoadOrder()
        {
            EnableModules = new List<IModule>();
            DisableModules = new List<IModule>();

            SeparateModules();

            foreach(IModule module in EnableModules)
            {
                module.ModuleStart();
            }

            AnimaCentral.Reinitialise();
        }

        ~PluginManager()
        {
            EndModules();
        }

        public void TickAll()
        {
            foreach(IModule module in EnableModules)
            {
                module.ModuleTick();
            }
        }

        private void Compose(string PluginDirectory)
        {

            var ModuleFiles = FindModules(PluginDirectory);

            AggregateCatalog catalog = new AggregateCatalog();
            foreach (var module in ModuleFiles)
            {
                AssemblyCatalog asscat = new AssemblyCatalog(module);
                catalog.Catalogs.Add(asscat);
            }

            var PluginExportProvider = new CatalogExportProvider(catalog);
            var AppExportProvider = new CatalogExportProvider(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));


            CompositionContainer container = new CompositionContainer(PluginExportProvider, AppExportProvider);

            AppExportProvider.SourceProvider = container;
            PluginExportProvider.SourceProvider = container;


            container.SatisfyImportsOnce(this);
        }

        private void SeparateModules()
        {
            List<IModule> AllModules = modules.ToList();
            List<int> MissingModuleIndexes = new List<int>();

            EnableModules = new List<IModule>();
            DisableModules = new List<IModule>();

            System.Collections.Specialized.StringCollection LoadOrder = Properties.CoreSettings.Default.LoadOrder;

            for(int i = 0; i < LoadOrder.Count; i++)
            {
                IModule module = AllModules.Find(x => x.ModuleName == LoadOrder[i]);
                if(module == null) { MissingModuleIndexes.Add(i); continue; }

                EnableModules.Add(module);
                AllModules.Remove(module);
            }

            foreach(var remainingModule in AllModules)
            {
                DisableModules.Add(remainingModule);
            }

            MissingModuleIndexes.Reverse(); //As indices are ascending and removing an early index will shift all others.
            foreach (int Missing in MissingModuleIndexes)
            {
                LoadOrder.RemoveAt(Missing);
            }

            Properties.CoreSettings.Default.LoadOrder = LoadOrder;
            Properties.CoreSettings.Default.Save();
        }

        private static List<string> FindModules(string Path)
        {
            List<string> Files = new List<string>(Directory.GetFiles(Path));
            Files = Files.Select(f => f.ToLower()).ToList();

            List<string> Modules = Files.Where(f => f.EndsWith(".dll")).ToList();
            return Modules;
        }

        public IEnumerable<IModule> GetActiveModules()
        {
            return EnableModules;
        }
        public IEnumerable<IModule> GetInactiveModules()
        {
            return DisableModules;
        }
    }
}

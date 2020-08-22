using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Anima.Core.Forms
{
    /*
        Format for a program Command (Single String, semi-colon delimited):
        Name; (Used to make the command text)
        Path; (File Path)
        Args; (Colon Delimited, numbers auto converted to int)
        Reply (Optional)
    */

    public partial class ProgramOpenManager : Form
    {
        public ProgramOpenManager()
        {
            InitializeComponent();
        }

        List<Command> AllProgramCommands;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ProgramOpen PO = new ProgramOpen(CallBackFunc);
            PO.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ProgramListBox.SelectedIndex < 0) { return; }
            ProgramOpen PO = new ProgramOpen((string)ProgramListBox.SelectedItem,CallBackFunc);
            PO.Show();
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (ProgramListBox.SelectedIndex < 0) { return; }

            string command = (string)ProgramListBox.SelectedItem;

            System.Collections.Specialized.StringCollection CustomOpens = Properties.CoreSettings.Default.CustomProgramOpens;
            CustomOpens.Remove(command);
            Properties.CoreSettings.Default.CustomProgramOpens = CustomOpens;
            Properties.CoreSettings.Default.Save();
            ProgramOpenManager_Load(this, new EventArgs());
        }

        private void ProgramOpenManager_Load(object sender, EventArgs e)
        {
            ClearExistingProgramCommands();
            ProgramListBox.Items.Clear();

            List<int> MissingFileIndexes = new List<int>();
            var CustomOpens = Properties.CoreSettings.Default.CustomProgramOpens;

            if (CustomOpens == null)
            {
               CustomOpens = new System.Collections.Specialized.StringCollection();
            }

            for (int i = 0; i < CustomOpens.Count; i++)
            {
                string pc = CustomOpens[i];

                List<string> Sections = pc.Split(new char[] { ';' }).ToList();
                if (Sections.Count < 3) { MissingFileIndexes.Add(i); continue; }

                string Phrase = Sections[0];
                string path = Sections[1];
                string Args = Sections[2];
                string Reply = Sections.Count > 3 ? Sections[3] : String.Empty;

                if (!File.Exists(path) && !Utilities.WebAddressExists(path)) { MissingFileIndexes.Add(i); continue; }

                var Arguments = ProduceArgs(Args);

                if(Arguments.Length == 0)
                {
                    Command c = new Command(Phrase, Utilities.OpenFile(path, Reply));
                    AnimaCentral.RegisterCommand(c);
                    AllProgramCommands.Add(c);
                }
                else
                {
                    Command c = new Command(Phrase, Utilities.OpenFile(path, Reply,Arguments),Args: Arguments);
                    AnimaCentral.RegisterCommand(c);
                    AllProgramCommands.Add(c);
                }

                
                ProgramListBox.Items.Add(pc);
            }

            MissingFileIndexes.Reverse(); //Due to removal Process

            foreach(int index in MissingFileIndexes)
            {
                CustomOpens.RemoveAt(index);
            }

            Properties.CoreSettings.Default.CustomProgramOpens = CustomOpens;
            Properties.CoreSettings.Default.Save();
        }

        private string[] ProduceArgs(string Args)
        {
            return Args.Split(new char[] { ':' });
        }

        private void ClearExistingProgramCommands()
        {
            if(AllProgramCommands == null) { AllProgramCommands = new List<Command>(); return; }

            foreach(var c in AllProgramCommands)
            {
                AnimaCentral.UnregisterCommand(c);
            }

            AllProgramCommands = new List<Command>();
        }

        private void CallBackFunc(string CustomCommand)
        {
            System.Collections.Specialized.StringCollection CustomOpens = Properties.CoreSettings.Default.CustomProgramOpens;

            if (CustomOpens.Contains(CustomCommand)) { return; }

            CustomOpens.Add(CustomCommand);
            Properties.CoreSettings.Default.CustomProgramOpens = CustomOpens;
            Properties.CoreSettings.Default.Save();
            ProgramOpenManager_Load(this, new EventArgs());
        }
    }
}

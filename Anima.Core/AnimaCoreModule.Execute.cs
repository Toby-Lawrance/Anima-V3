using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Anima.Core
{
    public class AnimaCoreModule : IModule
    {
        public string ModuleName => "Anima Core";

        public string ModuleDescription => "Core Module - Top Of Load Order";

        public string ModuleAuthor => "Toby Lawrance";

        private Forms.ProgramOpenManager POM = new Forms.ProgramOpenManager();

        private static string GooglePhrase = Command.NamePhrase +  "could you look up ";

        public void ModuleStart()
        {
            Command LoadOrderOpen = new Command("I would like to change the Load Order", Utilities.OpenForm(new LoadOrderManager(),"Of Course"));
            Command VoiceSelectOpen = new Command("I would like to change your voice", Utilities.OpenForm(new Forms.VoiceSelection(), "Of Course"));
            Command ProgramOpenManager = new Command("I would like to change my program opens", Utilities.OpenForm(POM, "Of Course"));
            Command ShowCommandList = new Command("Show the Command List", Utilities.OpenForm(new Forms.Command_List(), "Here's the commands"));

            GrammarBuilder gb = new GrammarBuilder(GooglePhrase);
            gb.AppendDictation();
            Grammar googlegrammar = new Grammar(gb);
            Command Google = new Command(GooglePhrase + "...", googlegrammar, this.Google,0.8);

            Command Reply = new Command("I wish to hear your voice", Utilities.GiveReply("Of course, This is my voice, The Quick Brown Fox Jumped Over The Lazy Dog"));

            AnimaCentral.RegisterCommand(LoadOrderOpen,VoiceSelectOpen,ProgramOpenManager,ShowCommandList,Google,Reply);

            //Registers existing custom Programs
            AnimaCentral.SendUpdate(new AnimaEventArgs(POM));
            POM.Show();
            POM.Hide();
        }

        public void ModuleTick()
        {

        }

        public void ModuleEnd()
        {

        }

        private void Google(RecognitionResult r)
        {
            string input = r.Text;
            string Term = input.Substring(GooglePhrase.Length).Replace(' ','+');
            string GoogleURL = @"http://google.com/search?q=";
            Utilities.OpenFile(GoogleURL + Term, "Looking up: " + Term.Replace('+', ' '))(r);
        }

    }
}

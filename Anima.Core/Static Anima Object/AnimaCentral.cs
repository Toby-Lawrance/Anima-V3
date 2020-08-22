using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Windows;

namespace Anima.Core
{
    public static partial class AnimaCentral
    {
        private const string DefaultImageResource = @"pack://application:,,,/Anima.Core;component/Resources/BluePasukon.png";
        
        public static void Initialise(Window Display)
        {
            AnimaCentral.SpeechEngine = new SpeechRecognitionEngine(System.Globalization.CultureInfo.CurrentCulture);

            AnimaCentral._displayWindow = Display;

            AnimaCentral.Voice = new SpeechSynthesizer();
            AnimaCentral.Voice.SetOutputToDefaultAudioDevice();
            if(Properties.CoreSettings.Default.Voice == String.Empty)
            {
                Properties.CoreSettings.Default.Voice = AnimaCentral.Voice.Voice.Name;
                Properties.CoreSettings.Default.Save();
            } else
            {
                AnimaCentral.Voice.SelectVoice(Properties.CoreSettings.Default.Voice);
            }


            AnimaCentral.Image = new BitmapImage(new Uri(DefaultImageResource, UriKind.RelativeOrAbsolute));

            AnimaCentral.SpeechQueue = new Queue<Prompt>();

            AnimaCentral.Pos = new Position(0,0);

            AnimaCentral.Commands = new List<Command>();

            AnimaCentral.PlugMan = new PluginManager();

            ShuttingDown = false;

            var NumberChoices = new Choices();
            for(int i = 0; i <= 100; i++)
            {
                NumberChoices.Add(i.ToString());
            }
            Numbers = NumberChoices;

            InitialiseSpeech();
        }

     public static void Reinitialise()
        {
            AnimaCentral.SpeechEngine = new SpeechRecognitionEngine(System.Globalization.CultureInfo.CurrentCulture);

            AnimaCentral.Voice = new SpeechSynthesizer();
            AnimaCentral.Voice.SetOutputToDefaultAudioDevice();

            AnimaCentral.Image = Image == null ? new BitmapImage(new Uri(DefaultImageResource, UriKind.Relative)) : Image;

            AnimaCentral.SpeechQueue = new Queue<Prompt>();

            AnimaCentral.Pos = BottomRightMainScreen(WindowWidth,WindowHeight);

            AnimaCentral.Commands = new List<Command>();

            ShuttingDown = false;

            InitialiseSpeech();
        }

        public static void InitialiseSpeech()
        {
            if (Commands.Count > 0)
            {
                foreach (var C in Commands)
                {
                    if(SpeechEngine.Grammars.Contains(C.grammar)) { continue; }
                    SpeechEngine.LoadGrammar(C.grammar);
                }

                SpeechEngine.SetInputToDefaultAudioDevice();

                SpeechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        public static void SendUpdate()
        {
            EventHandler<AnimaEventArgs> handler = AnimaCentral.AnimaUpdate;
            if (handler != null)
            {
                ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;
                target.InvokeIfRequired(() => handler(null, new AnimaEventArgs()));
            }
        }
        public static void SendUpdate(AnimaEventArgs e)
        {
            EventHandler<AnimaEventArgs> handler = AnimaCentral.AnimaUpdate;
            if (handler != null)
            {
                ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;

                if (target != null && target.InvokeRequired)
                {
                    target.Invoke(handler, new object[] { null, e });
                }
                else
                {
                    handler(null,e);
                }
            }
        }

        public static void QueuePhrase(params string[] Phrases)
        {
            foreach (var Phrase in Phrases)
            {
                Prompt Message = new Prompt(Phrase);
                AnimaCentral.SpeechQueue.Enqueue(Message);
            }
        }

        public static void ClearSpeechQueue()
        {
            SpeechQueue.Clear();
        }

        public static void Speak()
        {
            if (AnimaCentral.SpeechQueue.Count > 0)
            {
                Prompt Message = AnimaCentral.SpeechQueue.Dequeue();
                AnimaCentral.Voice.SpeakAsync(Message);
            }
        }

        public static void Speak(params string[] Phrases)
        {
            QueuePhrase(Phrases);
            SpeakAll();
        }

        public static void SpeakAll()
        {
            while(AnimaCentral.SpeechQueue.Count > 0)
            {
                if(AnimaCentral.Voice.State == SynthesizerState.Ready)
                {
                    Speak();
                }
            }
        }

        public static void RegisterCommand(params Command[] ToRegister)
        {
            foreach(Command c in ToRegister)
            {
                Commands.Add(c);
                SpeechEngine.LoadGrammar(c.grammar);
            }   
        }

        public static void RegisterCommand(IEnumerable<Command> All)
        {
            RegisterCommand(All.ToArray());
        }

        public static void UnregisterCommand(params Command[] ToRegister)
        {
            foreach(Command c in ToRegister)
            {
                int Removed = Commands.RemoveAll(x => x.ID.ToString() == c.ID.ToString());
                SpeechEngine.UnloadGrammar(c.grammar);
            }
        }

        public static void UnregisterCommand(IEnumerable<Command> All)
        {
            UnregisterCommand(All.ToArray());
        }

        private static double WindowWidth;
        private static double WindowHeight;
        public static Position BottomRightMainScreen(double Width, double Height)
        {
            WindowHeight = Height;
            WindowWidth = Width;

            Screen Main = Screen.PrimaryScreen;
            return new Position(Main.WorkingArea.Width - Width, Main.WorkingArea.Height - Height);
        }

        

        public static void Shutdown()
        {
            PlugMan.EndModules();

            do
            {
                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(500);
            } while (SpeechQueue.Count > 0);

        }
    }
}

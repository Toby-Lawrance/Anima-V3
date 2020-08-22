using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Media;
using System.Windows;

namespace Anima.Core
{
    public static partial class AnimaCentral
    {
        public static event EventHandler<AnimaEventArgs> AnimaUpdate;

        private static Position _pos;
        public static Position Pos
        {
            get { return _pos; }
            set { _pos = value; SendUpdate(); }
        }

        private static ImageSource _image;
        public static ImageSource Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private static SpeechSynthesizer _voice;
        public static SpeechSynthesizer Voice
        {
            get { return _voice; }
            set { _voice = value; }
        }

        private static SpeechRecognitionEngine _engine;
        public static SpeechRecognitionEngine SpeechEngine
        {
            get { return _engine; }
            set { _engine = value; }
        }

        private static Queue<Prompt> _speechQueue;
        public static Queue<Prompt> SpeechQueue
        {
            get { return _speechQueue; }
            set { _speechQueue = value; }
        }

        private static List<Command> _commands;
        public static List<Command> Commands
        {
            get { return _commands; }
            private set { _commands = value; }
        }

        private static Choices _Numbers;
        public static Choices Numbers
        {
            get { return _Numbers; }
            private set { _Numbers = value; }
        }

        private static bool _shuttingdown;
        public static bool ShuttingDown { get { return _shuttingdown; } private set { _shuttingdown = value; SendUpdate(); } }

        private static PluginManager _PlugMan;
        public static PluginManager PlugMan { get { return _PlugMan; } private set { _PlugMan = value; } }

        private static Window _displayWindow;
        public static Window DisplayWindow { get { return _displayWindow; } private set { _displayWindow = value; } }

    }
}

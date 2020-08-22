using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;

namespace Anima.Core
{
    public class Command
    {
        private const float ReductionRate = 100.0f;
        public static string NamePhrase = "Anima, ";

        public Guid ID;
        public Grammar grammar;
        public object[] Arguments;
        public string Name;
        
        public Command(string Name, Grammar _g, Action<RecognitionResult> _Method, double Confidence = 0.95)
        {
            ID = Guid.NewGuid();
            this.Name = Name;

            grammar = _g; 
            grammar.SpeechRecognized += delegate(object sender, SpeechRecognizedEventArgs e) { if (e.Result.Confidence >= Confidence) { _Method(e.Result); } };
        }

        public Command(string s, Action<RecognitionResult> _Method, double Confidence = 0.95)
        {
            s = NamePhrase + s;
            this.Name = s;
            ID = Guid.NewGuid();
            float ConfidenceReduction = s.Split(new char[] { ' ' }).Length /(float) ReductionRate; //Reduces needed confidence by 0.1 per word.

            var gb = new GrammarBuilder(s);
            grammar = new Grammar(gb);
            grammar.SpeechRecognized += delegate (object sender, SpeechRecognizedEventArgs e) { if (e.Result.Confidence >= Confidence - ConfidenceReduction) { _Method(e.Result); } };
        }

        public Command(string Name,Grammar _g, Action<RecognitionResult, object[]> _Method, double Confidence = 0.95 , object[] Args = null)
        {
            this.Name = Name;
            this.Arguments = Args;
            ID = Guid.NewGuid();
            grammar = _g;
            grammar.SpeechRecognized += delegate (object sender, SpeechRecognizedEventArgs e) { if (e.Result.Confidence >= Confidence) { _Method(e.Result,Args); } };
        }

        public Command(string s, Action<RecognitionResult, object[]> _Method, double Confidence = 0.95 ,  object[] Args = null)
        {
            s = NamePhrase + s;
            this.Name = s;
            this.Arguments = Args;
            ID = Guid.NewGuid();
            float ConfidenceReduction = s.Split(new char[] { ' ' }).Length / (float)ReductionRate; //Reduces needed confidence by 0.1 per word.
            Args = Args == null ? new object[0] : Args;
            var gb = new GrammarBuilder(s);
            grammar = new Grammar(gb);
            grammar.SpeechRecognized += delegate (object sender, SpeechRecognizedEventArgs e) { if (e.Result.Confidence >= Confidence - ConfidenceReduction) { _Method(e.Result, Args); } };
        }

    }
}

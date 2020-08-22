using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anima;
using Anima.Core;

namespace Core_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Initialise()
        {
            AnimaCentral.Initialise();
            Assert.IsFalse(AnimaCentral.SpeechEngine == null);
            Assert.IsFalse(AnimaCentral.Voice == null);
            Assert.IsFalse(AnimaCentral.Image == null);
        }

        [TestMethod]
        public void Speak()
        {
            AnimaCentral.Initialise();
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test1"));
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test2"));

            Assert.AreEqual<int>(2, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.Speak();
            Assert.AreEqual(1, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.Speak();
            Assert.AreEqual(0, AnimaCentral.SpeechQueue.Count);
        }

        [TestMethod]
        public void SpeakEmpty()
        {
            AnimaCentral.Initialise();
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test1"));
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test2"));

            Assert.AreEqual(2, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.Speak();
            Assert.AreEqual(1, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.Speak();
            Assert.AreEqual(0, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.Speak();
            Assert.AreEqual(0, AnimaCentral.SpeechQueue.Count);
        }

        [TestMethod]
        public void SpeakAll()
        {
            AnimaCentral.Initialise();
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test1"));
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test2"));
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test3"));
            AnimaCentral.SpeechQueue.Enqueue(new System.Speech.Synthesis.Prompt("Test4"));

            Assert.AreEqual(4, AnimaCentral.SpeechQueue.Count);
            AnimaCentral.SpeakAll();
            Assert.AreEqual(0, AnimaCentral.SpeechQueue.Count);

        }

        [TestMethod]
        public void UpdateCheck()
        {
            AnimaCentral.Initialise();
            bool EventFired = false;
            AnimaCentral.AnimaUpdate += delegate(object sender, AnimaEventArgs e) { EventFired = true; };
            AnimaCentral.SendUpdate();
            Assert.IsTrue(EventFired);
        }

        [TestMethod]
        public void PositionSet()
        {
            AnimaCentral.Pos = new Position(0, 0);
            MainWindow MW = new MainWindow();
            AnimaCentral.SendUpdate();
            Assert.AreEqual(MW.Left, AnimaCentral.Pos.X);
            Assert.AreEqual(MW.Top, AnimaCentral.Pos.Y);
        }
        [TestMethod]
        public void PositionShift()
        {
            AnimaCentral.Pos = new Position(0, 0);
            MainWindow MW = new MainWindow();
            AnimaCentral.SendUpdate();
            Assert.AreEqual(MW.Left, AnimaCentral.Pos.X);
            Assert.AreEqual(MW.Top, AnimaCentral.Pos.Y);
            AnimaCentral.Pos = new Position(200, 200);
            AnimaCentral.SendUpdate();
            Assert.AreEqual(MW.Left, AnimaCentral.Pos.X);
            Assert.AreEqual(MW.Top, AnimaCentral.Pos.Y);
        }

    }
}

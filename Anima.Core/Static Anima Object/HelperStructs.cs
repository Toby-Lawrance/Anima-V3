using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace Anima.Core
{
    public class Position
    {
        private double _x;
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Position(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool SetWindowPosition(Window W)
        {
            W.Left = this.X;
            W.Top = this.Y;

            return true;
        }
    }

    public class AnimaEventArgs : EventArgs
    {
        public string Message
        { get; private set; }

        public Form form
        { get; private set; }

        public AnimaEventArgs()
        {

        }

        public AnimaEventArgs(string s)
        {
            this.Message = s;
        }

        public AnimaEventArgs(Form f)
        {
            this.form = f;
        }
    }

    public static class Utilities
    {
        public static Action<RecognitionResult> GiveReply(string Reply, Action Method = null)
        {
            Action<RecognitionResult> Outcome;
            if(Method != null)
            {
                Outcome = delegate (RecognitionResult r) { Method(); Anima.Core.AnimaCentral.Speak(Reply); };
            } else
            {
                Outcome = delegate (RecognitionResult r) { Anima.Core.AnimaCentral.Speak(Reply); };
            }
            return Outcome;
        }

        public static Action<RecognitionResult> OpenFile(string Path, string Reply = null)
        {
            Action<RecognitionResult> Outcome;

            if(File.Exists(Path) || Utilities.WebAddressExists(Path))
            {
                if (!String.IsNullOrEmpty(Reply))
                {
                    Outcome = delegate (RecognitionResult r) { Process.Start(Path); Anima.Core.AnimaCentral.Speak(Reply); };
                }
                else
                {
                    Outcome = delegate (RecognitionResult r) { Process.Start(Path); };
                }
                return Outcome;
            }

            throw new Exception("Error creating Command");
        }

        public static Action<RecognitionResult,object[]> OpenFile(string Path, string Reply = null, params string[] args)
        {
            Action<RecognitionResult,object[]> Outcome;

            string Arguments = "";
            foreach(var arg in args)
            {
                Arguments = String.Concat(Arguments ," ", arg.ToString());
            }

            Arguments = Arguments.TrimStart();

            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = Path;
            StartInfo.Arguments = Arguments;

            if (File.Exists(Path) || Utilities.WebAddressExists(Path))
            {
                if (!String.IsNullOrEmpty(Reply))
                {
                    Outcome = delegate (RecognitionResult r, object[] arguments) { Process.Start(StartInfo); Anima.Core.AnimaCentral.Speak(Reply); };
                }
                else
                {
                    Outcome = delegate (RecognitionResult r, object[] arguments) { Process.Start(StartInfo); };
                }
                return Outcome;
            }

            throw new Exception("Error creating Command");
        }

        public static Action<RecognitionResult> OpenForm(Form F, string Reply = null)
        {
            Action<RecognitionResult> Outcome;

            if (F != null)
            {
                if (!String.IsNullOrEmpty(Reply))
                {
                    Outcome = delegate (RecognitionResult r)
                    {
                        AnimaEventArgs e = new AnimaEventArgs(F);
                        AnimaCentral.SendUpdate(e);
                        Anima.Core.AnimaCentral.Speak(Reply);
                    };
                }
                else
                {
                    Outcome = delegate (RecognitionResult r)
                    {
                        AnimaEventArgs e = new AnimaEventArgs(F);
                        AnimaCentral.SendUpdate(e);
                    };
                }
                return Outcome;
            }

            throw new Exception("Error creating Command");
        }

        public static bool WebAddressExists(string url)
        {

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }

        }

       public static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        
    }

    public static class Extensions
    {
        public static void InvokeIfRequired(this ISynchronizeInvoke f, MethodInvoker action)
        {
            if (f != null && f.InvokeRequired)
            {
                var args = new object[0];
                f.Invoke(action, args);
            }
            else { action(); }
        }
    }
}
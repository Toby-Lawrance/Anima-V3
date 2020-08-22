using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anima
{
    class TraySystem
    {
        private NotifyIcon m_notifyIcon;
        private ContextMenu TrayMenu;

        public TraySystem()
        {
            TrayMenu = new ContextMenu();
            TrayMenu.Name = "Anima";
            TrayMenu.MenuItems.Add("Exit", Close);

            m_notifyIcon = new NotifyIcon();
            m_notifyIcon.Text = "Anima";
            m_notifyIcon.Visible = true;
            m_notifyIcon.Icon = new System.Drawing.Icon(SystemIcons.Information, 40, 40);
            m_notifyIcon.ContextMenu = TrayMenu;
        }

        private void Close(object sender, EventArgs e)
        {
            Anima.Core.AnimaCentral.Shutdown();
            while(SynthesizerState.Speaking == Anima.Core.AnimaCentral.Voice.State || Anima.Core.AnimaCentral.SpeechQueue.Count > 0)
            {
                Application.DoEvents();
            }
            App.Current.Shutdown();
        }
    }
}

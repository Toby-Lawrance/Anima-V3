using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Anima.Core.Forms
{
    public partial class VoiceSelection : Form
    {
        public VoiceSelection()
        {
            InitializeComponent();
        }

        List<InstalledVoice> Voices;
        SpeechSynthesizer Voice = new SpeechSynthesizer();

        private void VoicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Voice.SpeakAsyncCancelAll();
            Voice.SelectVoice(Voices[VoicesListBox.SelectedIndex].VoiceInfo.Name);

            TrySpeak();
        }

        private void TrySpeak()
        {
            try
            {
                Voice.Volume = 100;
                Voice.SpeakAsync("Hello. I am Anima, Do you like this voice?");
            }
            catch
            {
                //Add visual view
            }

        }

        private void UpdateVoice_Click(object sender, EventArgs e)
        {
            AnimaCentral.Voice.SelectVoice(Voices[VoicesListBox.SelectedIndex].VoiceInfo.Name);
            Properties.CoreSettings.Default.Voice = Voices[VoicesListBox.SelectedIndex].VoiceInfo.Name;
            Properties.CoreSettings.Default.Save();

            Voice.SpeakAsyncCancelAll();

            this.Hide();
        }

        private void VoiceSelection_Load(object sender, EventArgs e)
        {
            this.SizeGripStyle = SizeGripStyle.Hide;
            Voices = new List<InstalledVoice>();

            Voices.AddRange(AnimaCentral.Voice.GetInstalledVoices());

            foreach (var Voice in Voices)
            {
                VoicesListBox.Items.Add(Voice.VoiceInfo.Name + " Gender: " + Voice.VoiceInfo.Gender + " Culture: " + Voice.VoiceInfo.Culture.NativeName);
            }
        }
    }
}

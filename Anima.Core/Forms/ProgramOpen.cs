using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anima.Core.Forms
{
    public partial class ProgramOpen : Form
    {
        string CustomCommand;
        Action<string> callback;

        public ProgramOpen(Action<string> Callback)
        {
            InitializeComponent();
            CustomCommand = String.Empty;
            callback = Callback;
        }

        public ProgramOpen(string ExistingCommand, Action<string> Callback)
        {
            InitializeComponent();
            CustomCommand = ExistingCommand;
            callback = Callback;
        }

        private void FileDialogBtn_Click(object sender, EventArgs e)
        {
            FileToOpenDialog.ShowDialog();
        }

        private void FileToOpenDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = FileToOpenDialog.FileName;
            string Name = Properties.CoreSettings.Default.ProgramOpenBasePhrase + Path.GetFileNameWithoutExtension(path);
            if (String.IsNullOrWhiteSpace(NameBox.Text)) { NameBox.Text = Name; }

            PathBox.Text = path;
            ReplyBox.Text = String.IsNullOrWhiteSpace(ReplyBox.Text) ? "Opening " + Path.GetFileNameWithoutExtension(path) : ReplyBox.Text;
        }

        private void ProgramOpen_Load(object sender, EventArgs e)
        {
            List<string> Sections = CustomCommand.Split(new char[] { ';' }).ToList();

            string Name = Sections.Count > 0 ? Sections[0] : String.Empty;
            string path = Sections.Count > 1 && (File.Exists(Sections[1]) || Utilities.WebAddressExists(Sections[1])) ? Sections[1] : String.Empty;
            string Args = Sections.Count > 2 ? Sections[2] : String.Empty;
            string Reply = Sections.Count > 3 ? Sections[3] : String.Empty;

            NameBox.Text = Name;
            PathBox.Text = path;
            ArgsBox.Text = Args;
            ReplyBox.Text = Reply;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string Name = NameBox.Text;
            string path = PathBox.Text;
            string Args = ArgsBox.Text;
            string Reply = ReplyBox.Text;

            if(String.IsNullOrWhiteSpace(Name)) { return; }
            if(!File.Exists(path) && !Utilities.WebAddressExists(path)) { return; }

            string command = Name + ';' + path + ';' + Args + ';' + Reply;

            callback(command);

            this.Close();
        }

        

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anima.Core.Forms
{
    public partial class Command_List : Form
    {
        public Command_List()
        {
            InitializeComponent();
        }

        private void Command_List_Load(object sender, EventArgs e)
        {
            CommandList.Items.Clear();
            foreach(var c in AnimaCentral.Commands)
            {
                CommandList.Items.Add(c.Name);
            }
        }

        private void CommandList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

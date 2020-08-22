using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Anima.Core
{
    public partial class LoadOrderManager : Form
    {
        public LoadOrderManager()
        {
            InitializeComponent();
        }

        private void LoadOrderManager_Load(object sender, EventArgs e)
        {
            LoadOrderList.Items.Clear();
            var ActiveModules = AnimaCentral.PlugMan.GetActiveModules();

            foreach (var m in ActiveModules)
            {
                string module = m.ModuleName + ": " + m.ModuleDescription;
                LoadOrderList.Items.Add(module,true);
            }

            var InactiveModules = AnimaCentral.PlugMan.GetInactiveModules();
            foreach (var m in InactiveModules)
            {
                string module = m.ModuleName + ": " + m.ModuleDescription;
                LoadOrderList.Items.Add(module, false);
            }

        }

        private void LoadOrderList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.Index == 0 && e.NewValue == CheckState.Unchecked) {e.NewValue = CheckState.Checked; }
        }

        private void UpLoadOrder_Click(object sender, EventArgs e)
        {
            if(LoadOrderList.SelectedIndex <= 1) { return; }

            int Index = LoadOrderList.SelectedIndex;
            int IndexAbove = Index - 1;

            var item = LoadOrderList.Items[Index]; bool isChecked = LoadOrderList.GetItemChecked(Index);
            var itemAbove = LoadOrderList.Items[IndexAbove]; bool isCheckedAbove = LoadOrderList.GetItemChecked(IndexAbove);

            LoadOrderList.Items[IndexAbove] = item; LoadOrderList.SetItemChecked(IndexAbove, isChecked);
            LoadOrderList.Items[Index] = itemAbove; LoadOrderList.SetItemChecked(Index, isCheckedAbove);

            LoadOrderList.SelectedIndex--;

        }

        private void DownLoadOrder_Click(object sender, EventArgs e)
        {
            if(LoadOrderList.SelectedIndex <= 0 ||  LoadOrderList.SelectedIndex == LoadOrderList.Items.Count - 1) { return; }

            int Index = LoadOrderList.SelectedIndex;
            int IndexBelow = Index + 1;

            var item = LoadOrderList.Items[Index]; bool isChecked = LoadOrderList.GetItemChecked(Index);
            var itemBelow = LoadOrderList.Items[IndexBelow]; bool isCheckedBelow = LoadOrderList.GetItemChecked(IndexBelow);

            LoadOrderList.Items[IndexBelow] = item; LoadOrderList.SetItemChecked(IndexBelow, isChecked);
            LoadOrderList.Items[Index] = itemBelow; LoadOrderList.SetItemChecked(Index, isCheckedBelow);

            LoadOrderList.SelectedIndex++;

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            LoadOrderManager_Load(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(LoadOrderList.SelectedIndex <= 0) { return; }

            int Index = LoadOrderList.SelectedIndex;

            if(LoadOrderList.GetItemChecked(Index) == false) { LoadOrderList.SetItemChecked(Index, true); } else { LoadOrderList.SetItemChecked(Index, false); }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            List<string> ActiveModules = new List<string>();

            for(int i = 0; i < LoadOrderList.CheckedItems.Count; i++)
            {
                string Name = LoadOrderList.CheckedItems[i].ToString().Split(new char[] { ':' }).FirstOrDefault();
                ActiveModules.Add(Name);
            }
            System.Collections.Specialized.StringCollection s = new System.Collections.Specialized.StringCollection();
            s.AddRange(ActiveModules.ToArray());
            Properties.CoreSettings.Default.LoadOrder = s;
            Properties.CoreSettings.Default.Save();

            AnimaCentral.PlugMan.SortLoadOrder();

            this.Hide();
        }
    }
}

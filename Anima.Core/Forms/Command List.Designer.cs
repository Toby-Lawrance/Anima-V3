namespace Anima.Core.Forms
{
    partial class Command_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommandList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CommandList
            // 
            this.CommandList.FormattingEnabled = true;
            this.CommandList.Location = new System.Drawing.Point(13, 13);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(374, 368);
            this.CommandList.TabIndex = 0;
            this.CommandList.SelectedIndexChanged += new System.EventHandler(this.CommandList_SelectedIndexChanged);
            // 
            // Command_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 396);
            this.Controls.Add(this.CommandList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Command_List";
            this.Text = "Command_List";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Command_List_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CommandList;
    }
}
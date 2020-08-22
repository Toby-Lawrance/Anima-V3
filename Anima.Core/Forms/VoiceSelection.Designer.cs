namespace Anima.Core.Forms
{
    partial class VoiceSelection
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
            this.VoicesListBox = new System.Windows.Forms.ListBox();
            this.UpdateVoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VoicesListBox
            // 
            this.VoicesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VoicesListBox.FormattingEnabled = true;
            this.VoicesListBox.Location = new System.Drawing.Point(13, 13);
            this.VoicesListBox.Name = "VoicesListBox";
            this.VoicesListBox.Size = new System.Drawing.Size(329, 329);
            this.VoicesListBox.TabIndex = 0;
            this.VoicesListBox.SelectedIndexChanged += new System.EventHandler(this.VoicesListBox_SelectedIndexChanged);
            // 
            // UpdateVoice
            // 
            this.UpdateVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateVoice.Location = new System.Drawing.Point(13, 348);
            this.UpdateVoice.Name = "UpdateVoice";
            this.UpdateVoice.Size = new System.Drawing.Size(83, 23);
            this.UpdateVoice.TabIndex = 1;
            this.UpdateVoice.Text = "Confirm";
            this.UpdateVoice.UseVisualStyleBackColor = true;
            this.UpdateVoice.Click += new System.EventHandler(this.UpdateVoice_Click);
            // 
            // VoiceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 382);
            this.Controls.Add(this.UpdateVoice);
            this.Controls.Add(this.VoicesListBox);
            this.Name = "VoiceSelection";
            this.Text = "VoiceSelection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VoiceSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox VoicesListBox;
        private System.Windows.Forms.Button UpdateVoice;
    }
}
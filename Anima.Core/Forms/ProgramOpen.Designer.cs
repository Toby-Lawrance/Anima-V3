namespace Anima.Core.Forms
{
    partial class ProgramOpen
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.FileToOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileDialogBtn = new System.Windows.Forms.Button();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReplyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ArgsBox = new System.Windows.Forms.TextBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phrase";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(54, 10);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(167, 20);
            this.NameBox.TabIndex = 1;
            // 
            // FileToOpenDialog
            // 
            this.FileToOpenDialog.Filter = "Exes|*.exe|All files|*.*";
            this.FileToOpenDialog.SupportMultiDottedExtensions = true;
            this.FileToOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FileToOpenDialog_FileOk);
            // 
            // FileDialogBtn
            // 
            this.FileDialogBtn.Location = new System.Drawing.Point(227, 8);
            this.FileDialogBtn.Name = "FileDialogBtn";
            this.FileDialogBtn.Size = new System.Drawing.Size(155, 23);
            this.FileDialogBtn.TabIndex = 0;
            this.FileDialogBtn.Text = "Find file";
            this.FileDialogBtn.UseVisualStyleBackColor = true;
            this.FileDialogBtn.Click += new System.EventHandler(this.FileDialogBtn_Click);
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(54, 37);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(328, 20);
            this.PathBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path";
            // 
            // ReplyBox
            // 
            this.ReplyBox.Location = new System.Drawing.Point(54, 64);
            this.ReplyBox.Name = "ReplyBox";
            this.ReplyBox.Size = new System.Drawing.Size(328, 20);
            this.ReplyBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reply";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Args";
            // 
            // ArgsBox
            // 
            this.ArgsBox.Location = new System.Drawing.Point(55, 91);
            this.ArgsBox.Name = "ArgsBox";
            this.ArgsBox.Size = new System.Drawing.Size(327, 20);
            this.ArgsBox.TabIndex = 4;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(16, 134);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(91, 23);
            this.ConfirmBtn.TabIndex = 9;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(307, 134);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 10;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ProgramOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 169);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.ArgsBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ReplyBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.FileDialogBtn);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramOpen";
            this.Text = "ProgramOpen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProgramOpen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.OpenFileDialog FileToOpenDialog;
        private System.Windows.Forms.Button FileDialogBtn;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReplyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ArgsBox;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}
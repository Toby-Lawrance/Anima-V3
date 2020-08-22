namespace Anima.Core
{
    partial class LoadOrderManager
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
            this.LoadOrderList = new System.Windows.Forms.CheckedListBox();
            this.UpLoadOrder = new System.Windows.Forms.Button();
            this.DownLoadOrder = new System.Windows.Forms.Button();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadOrderList
            // 
            this.LoadOrderList.FormattingEnabled = true;
            this.LoadOrderList.Location = new System.Drawing.Point(13, 13);
            this.LoadOrderList.Name = "LoadOrderList";
            this.LoadOrderList.Size = new System.Drawing.Size(363, 424);
            this.LoadOrderList.TabIndex = 0;
            this.LoadOrderList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LoadOrderList_ItemCheck);
            // 
            // UpLoadOrder
            // 
            this.UpLoadOrder.Location = new System.Drawing.Point(382, 146);
            this.UpLoadOrder.Name = "UpLoadOrder";
            this.UpLoadOrder.Size = new System.Drawing.Size(29, 49);
            this.UpLoadOrder.TabIndex = 1;
            this.UpLoadOrder.Text = "↑";
            this.UpLoadOrder.UseVisualStyleBackColor = true;
            this.UpLoadOrder.Click += new System.EventHandler(this.UpLoadOrder_Click);
            // 
            // DownLoadOrder
            // 
            this.DownLoadOrder.Location = new System.Drawing.Point(382, 232);
            this.DownLoadOrder.Name = "DownLoadOrder";
            this.DownLoadOrder.Size = new System.Drawing.Size(29, 49);
            this.DownLoadOrder.TabIndex = 2;
            this.DownLoadOrder.Text = "↓";
            this.DownLoadOrder.UseVisualStyleBackColor = true;
            this.DownLoadOrder.Click += new System.EventHandler(this.DownLoadOrder_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Location = new System.Drawing.Point(12, 443);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(84, 27);
            this.ApplyBtn.TabIndex = 3;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(102, 443);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 27);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(383, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "I/O";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoadOrderManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.DownLoadOrder);
            this.Controls.Add(this.UpLoadOrder);
            this.Controls.Add(this.LoadOrderList);
            this.Name = "LoadOrderManager";
            this.Text = "LoadOrderManager";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadOrderManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LoadOrderList;
        private System.Windows.Forms.Button UpLoadOrder;
        private System.Windows.Forms.Button DownLoadOrder;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button button1;
    }
}
namespace Prototype_Solution
{
    partial class JB_screen
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
            this.listBox_songs = new System.Windows.Forms.ListBox();
            this.textNowP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox_songs
            // 
            this.listBox_songs.BackColor = System.Drawing.SystemColors.Window;
            this.listBox_songs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_songs.FormattingEnabled = true;
            this.listBox_songs.Items.AddRange(new object[] {
            "No songs added"});
            this.listBox_songs.Location = new System.Drawing.Point(0, 0);
            this.listBox_songs.Margin = new System.Windows.Forms.Padding(0);
            this.listBox_songs.Name = "listBox_songs";
            this.listBox_songs.Size = new System.Drawing.Size(284, 241);
            this.listBox_songs.TabIndex = 0;
            // 
            // textNowP
            // 
            this.textNowP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textNowP.Location = new System.Drawing.Point(0, 241);
            this.textNowP.Margin = new System.Windows.Forms.Padding(0);
            this.textNowP.Name = "textNowP";
            this.textNowP.Size = new System.Drawing.Size(284, 20);
            this.textNowP.TabIndex = 1;
            // 
            // JB_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listBox_songs);
            this.Controls.Add(this.textNowP);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Name = "JB_screen";
            this.Text = "JB_screen";
            this.Load += new System.EventHandler(this.JB_screen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBox_songs;
        public System.Windows.Forms.TextBox textNowP;





    }
}
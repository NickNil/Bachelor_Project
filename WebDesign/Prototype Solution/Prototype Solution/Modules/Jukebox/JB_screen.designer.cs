namespace BaseApplication
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
            this.labelSongs = new System.Windows.Forms.Label();
            this.textNowP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSongs
            // 
            this.labelSongs.BackColor = System.Drawing.Color.Transparent;
            this.labelSongs.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongs.ForeColor = System.Drawing.Color.Orange;
            this.labelSongs.Location = new System.Drawing.Point(0, 0);
            this.labelSongs.Name = "labelSongs";
            this.labelSongs.Size = new System.Drawing.Size(1042, 313);
            this.labelSongs.TabIndex = 2;
            this.labelSongs.Text = "No Songs";
            // 
            // textNowP
            // 
            this.textNowP.BackColor = System.Drawing.Color.Transparent;
            this.textNowP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textNowP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNowP.ForeColor = System.Drawing.Color.Orange;
            this.textNowP.Location = new System.Drawing.Point(0, 366);
            this.textNowP.Name = "textNowP";
            this.textNowP.Size = new System.Drawing.Size(1042, 29);
            this.textNowP.TabIndex = 3;
            this.textNowP.Text = "Now Playing:";
            this.textNowP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // JB_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textNowP);
            this.Controls.Add(this.labelSongs);
            this.Name = "JB_screen";
            this.Size = new System.Drawing.Size(1042, 395);
            this.Resize += new System.EventHandler(this.JB_screen_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelSongs;
        public System.Windows.Forms.Label textNowP;
    }
}
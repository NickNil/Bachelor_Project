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
            this.label1 = new System.Windows.Forms.Label();
            this.textNowP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1042, 313);
            this.label1.TabIndex = 2;
            this.label1.Text = "No Songs";
            // 
            // textNowP
            // 
            this.textNowP.BackColor = System.Drawing.Color.Transparent;
            this.textNowP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.textNowP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textNowP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNowP.ForeColor = System.Drawing.Color.Gold;
            this.textNowP.Location = new System.Drawing.Point(0, 366);
            this.textNowP.Name = "textNowP";
            this.textNowP.Size = new System.Drawing.Size(1042, 29);
            this.textNowP.TabIndex = 3;
            this.textNowP.Text = "Now Playing:";
            // 
            // JB_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textNowP);
            this.Controls.Add(this.label1);
            this.Name = "JB_screen";
            this.Size = new System.Drawing.Size(1042, 395);
            this.Resize += new System.EventHandler(this.JB_screen_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label textNowP;
    }
}
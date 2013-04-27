namespace Prototype_Solution
{
    partial class Chat_screen
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
            this.textChat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textChat
            // 
            this.textChat.AutoEllipsis = true;
            this.textChat.AutoSize = true;
            this.textChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChat.ForeColor = System.Drawing.Color.Orange;
            this.textChat.Location = new System.Drawing.Point(0, 0);
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(0, 29);
            this.textChat.TabIndex = 2;
            // 
            // Chat_screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textChat);
            this.DoubleBuffered = true;
            this.Name = "Chat_screen";
            this.Size = new System.Drawing.Size(927, 521);
            this.Resize += new System.EventHandler(this.Chat_screen_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label textChat;

    }
}
namespace Prototype_Solution
{
    partial class Chat_offscreen
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
            this.textToChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textToChat
            // 
            this.textToChat.Location = new System.Drawing.Point(28, 36);
            this.textToChat.Name = "textToChat";
            this.textToChat.Size = new System.Drawing.Size(219, 20);
            this.textToChat.TabIndex = 0;
            this.textToChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textToChat_TextChanged);
            // 
            // Chat_offscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textToChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chat_offscreen";
            this.Text = "Chat_offscreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textToChat;
    }
}
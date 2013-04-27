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
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.modChat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxChat
            // 
            this.listBoxChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.Location = new System.Drawing.Point(0, 0);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(870, 615);
            this.listBoxChat.TabIndex = 0;
            this.listBoxChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxChat_MouseDown);
            // 
            // modChat
            // 
            this.modChat.BackColor = System.Drawing.Color.Wheat;
            this.modChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.modChat.Location = new System.Drawing.Point(0, 595);
            this.modChat.Name = "modChat";
            this.modChat.Size = new System.Drawing.Size(870, 20);
            this.modChat.TabIndex = 1;
            this.modChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.modChat_KeyDown);
            // 
            // Chat_offscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modChat);
            this.Controls.Add(this.listBoxChat);
            this.Name = "Chat_offscreen";
            this.Size = new System.Drawing.Size(870, 615);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.TextBox modChat;

    }
}
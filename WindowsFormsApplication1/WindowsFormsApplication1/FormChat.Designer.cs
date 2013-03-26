namespace WindowsFormsApplication1
{
    partial class FormChat
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
            this.textChat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textChat
            // 
            this.textChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChat.Location = new System.Drawing.Point(0, 0);
            this.textChat.MaxLength = 100;
            this.textChat.Name = "textChat";
            this.textChat.ReadOnly = true;
            this.textChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.textChat.Size = new System.Drawing.Size(284, 261);
            this.textChat.TabIndex = 0;
            this.textChat.Text = "";
            this.textChat.TextChanged += new System.EventHandler(this.textChat_TextChanged);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox textChat;

    }
}
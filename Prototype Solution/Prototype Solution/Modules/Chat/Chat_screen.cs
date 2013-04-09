using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    public partial class Chat_screen : UserControl
    {
        delegate void SetTextCallback(string text);

        public Chat_screen()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.textChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textChat.Text += text;
            }
        }

        private void Chat_screen_Load(object sender, EventArgs e)
        {

        }

        private void textChat_TextChanged(object sender, EventArgs e)
        {           
            textChat.SelectionStart = textChat.Text.Length;
            textChat.ScrollToCaret();
            textChat.Text += Environment.NewLine;
        }
    }
}

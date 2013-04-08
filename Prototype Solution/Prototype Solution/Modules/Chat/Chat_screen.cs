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
        public Chat_screen()
        {
            InitializeComponent();
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

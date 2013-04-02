using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype
{
    public partial class Chat_screen : Form
    {
        public Chat_screen()
        {
            InitializeComponent();
        }

        private void FormChat_Load(object sender, EventArgs e)
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

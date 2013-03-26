using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormChat : Form
    {
        public FormChat()
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

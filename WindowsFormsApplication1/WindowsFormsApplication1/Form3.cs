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
    public partial class Form3 : Form
    {
        public Form3(Color color)
        {
            InitializeComponent();
            BackColor = color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = BackColor.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

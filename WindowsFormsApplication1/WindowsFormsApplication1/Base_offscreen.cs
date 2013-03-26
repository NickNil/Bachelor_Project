using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Prototype
{
    public partial class Base_offscreen : Form
    {
        Base_screen form2;
        public Jukebox jukebox;

        public Base_offscreen()
        {
            InitializeComponent();                                
        }       

        private void Form1_Load(object sender, EventArgs e)
        {            
            //Jukebox
            jukebox = new Jukebox(this);
            jukebox.jbPlayer.TopLevel = false;
            this.splitContainer1.Panel1.Controls.Add(jukebox.jbPlayer);
            jukebox.jbPlayer.Show();

            //Form2
            form2 = new Base_screen(this);
            form2.Show();
        }
   
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                form2.formChat.textChat.Text += textBox1.Text;
                textBox1.Clear();
            }
        }
    }
}

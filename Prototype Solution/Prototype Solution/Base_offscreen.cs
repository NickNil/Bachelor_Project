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
        Base_screen base_screen;
        public Jukebox jukebox;

        public Base_offscreen()
        {
            InitializeComponent();                                
        }

        private void Base_offscreen_Load(object sender, EventArgs e)
        {            
            //Jukebox
            jukebox = new Jukebox(this);
            jukebox.jb_offscreen.TopLevel = false;
            this.splitContainer1.Panel1.Controls.Add(jukebox.jb_offscreen);
            jukebox.jb_offscreen.Show();

            //Form2
            base_screen = new Base_screen(this);
            base_screen.Show();
        }
   
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                base_screen.chat_screen.textChat.Text += textBox1.Text;
                textBox1.Clear();
            }
        }
    }
}

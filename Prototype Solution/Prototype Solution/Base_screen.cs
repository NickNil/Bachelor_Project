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
    public partial class Base_screen : Form
    {
        Base_offscreen base_offscreen;
        public Chat_screen chat_screen;

        public Base_screen()
        {
            InitializeComponent();
        }

        public Base_screen(Base_offscreen frm)
        {
            InitializeComponent();
            base_offscreen = frm;
        }

        private void Base_screen_Load(object sender, EventArgs e)
        {
            chat_screen = new Chat_screen();
           

            chat_screen.TopLevel = false;
            base_offscreen.jukebox.jb_screen.TopLevel = false;
            
            this.splitContainer2.Panel2.Controls.Add(base_offscreen.jukebox.jb_screen);
            this.splitContainer2.Panel1.Controls.Add(chat_screen);

            chat_screen.Show();
            base_offscreen.jukebox.jb_screen.Show();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Prototype_Solution
{
    public partial class Base_offscreen : Form
    {
        Base_screen base_screen;
        public Jukebox jukebox;
        public Chat chat;

        public Base_offscreen()
        {
            InitializeComponent();                                
        }

        private void Base_offscreen_Load(object sender, EventArgs e)
        {            
            //Jukebox
            jukebox = new Jukebox(this);
            form_Load(jukebox.jb_offscreen, splitContainer1.Panel1);

            //Chat
            chat = new Chat(this);
            form_Load(chat.chat_offscreen, splitContainer1.Panel2);

            //Base_screen
            base_screen = new Base_screen(jukebox.jb_screen, chat.chat_screen);
            base_screen.Show();
        }

        private void form_Load(Form form, SplitterPanel location)
        {
            form.TopLevel = false;
            location.Controls.Add(form);
            form.Show(); 
        }
    }
}

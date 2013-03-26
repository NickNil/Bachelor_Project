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
        Base_offscreen form1;
        public FormChat formChat;

        public Base_screen(Base_offscreen frm)
        {
            InitializeComponent();
            form1 = frm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            formChat = new FormChat();
            Form3 form5 = new Form3(Color.Yellow);

            formChat.TopLevel = false;
            form1.jukebox.formJB.TopLevel = false;
            form5.TopLevel = false;

            this.splitContainer1.Panel2.Controls.Add(form5);
            this.splitContainer2.Panel2.Controls.Add(form1.jukebox.formJB);
            this.splitContainer2.Panel1.Controls.Add(formChat);

            formChat.Show();
            form1.jukebox.formJB.Show();
            form5.Show();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

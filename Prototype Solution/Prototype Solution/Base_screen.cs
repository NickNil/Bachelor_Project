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
    public partial class Base_screen : Form
    {
        Form form_1, form_2;

        public Base_screen()
        {
            InitializeComponent();
        }

        public Base_screen(Form frm1, Form frm2)
        {
            InitializeComponent();
            form_1 = frm1;
            form_2 = frm2;  
        }

        private void Base_screen_Load(object sender, EventArgs e)
        {
            //Jukebox
            form_Load(form_1, splitContainer2.Panel2);
            //Chat
            form_Load(form_2, splitContainer2.Panel1);          
        }

        private void form_Load(Form form, SplitterPanel location)
        {
            form.TopLevel = false;
            location.Controls.Add(form);
            form.Show(); 
        }
    }
}

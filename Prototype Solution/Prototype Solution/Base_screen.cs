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
        List<SplitterPanel> container = new List<SplitterPanel>();
        List<Start.modules> modList;

        public Base_screen()
        {
            InitializeComponent();
        }

        public Base_screen(List<Start.modules> list)
        {
            InitializeComponent();
            modList = list;
        }

        private void Base_screen_Load(object sender, EventArgs e)
        {
            container.Add(splitContainer2.Panel1);
            container.Add(splitContainer2.Panel2);
            container.Add(splitContainer1.Panel2);

            foreach (Start.modules item in modList)
            {
                form_Load(item.form, container[item.location]);
            }         
        }

        private void form_Load(Form form, SplitterPanel location)
        {
            form.TopLevel = false;
            location.Controls.Add(form);
            form.Show(); 
        }
    }
}

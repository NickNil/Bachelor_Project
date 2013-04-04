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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listView1.CheckedItems.Count >= 3)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count >= 1)
            {
                Base_offscreen base_offscreen = new Base_offscreen(listView1);
                this.Hide();
                base_offscreen.ShowDialog();
                this.Close();

            }
        }
    }
}

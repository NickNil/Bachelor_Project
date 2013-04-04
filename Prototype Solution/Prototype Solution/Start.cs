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

        private void button1_Click(object sender, EventArgs e)
        {
            ListView listView1 = new ListView();
           
            if(listBox2.Items.Count == 1)
                listView1.Items.Add(listBox2.Items[0].ToString());
            if (listBox3.Items.Count == 1)
                listView1.Items.Add(listBox3.Items[0].ToString());
            if (listBox4.Items.Count == 1)
                listView1.Items.Add(listBox4.Items[0].ToString());

            if (listView1.Items.Count <= 3)
            {
                Base_offscreen base_offscreen = new Base_offscreen(listView1);
                this.Hide();
                base_offscreen.ShowDialog();
                this.Close();

            }
        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox temp = (ListBox)sender;
            if (temp.Items.Count == 0)
                return;

            int index = temp.IndexFromPoint(e.X, e.Y);
            string s = temp.Items[index].ToString();
            DragDropEffects dde1 = DoDragDrop(s,
                DragDropEffects.All);

            if (dde1 == DragDropEffects.All)
            {
                temp.Items.RemoveAt(temp.IndexFromPoint(e.X, e.Y));
            }
        }

        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(
                    DataFormats.StringFormat);

                ListBox temp = (ListBox)sender;
                temp.Items.Add(str);
            }
        }
    }
}

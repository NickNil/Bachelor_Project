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
        public struct modules
        {
            public string name;
            public int location;
            public Form form;

            public modules(string name, int location)
            {
                this.name = name;
                this.location = location;
                form = null;
            }
        }

        public Start()
        {
            InitializeComponent();
        }

        private void Start_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<modules> list = new List<modules>();

            //listBox2
            if (listBox_0.Items.Count < 2)
            {
                if (listBox_0.Items.Count == 1)
                    list.Add(new modules(listBox_0.Items[0].ToString(), 0));
            }
            else
                return;

            //listBox3
            if (listBox_1.Items.Count < 2)
            {
                if (listBox_1.Items.Count == 1)
                    list.Add(new modules(listBox_1.Items[0].ToString(), 1));
            }
            else
                return;

            //listBox4
            if (listBox_2.Items.Count < 2)
            {
                if (listBox_2.Items.Count == 1)
                    list.Add(new modules(listBox_2.Items[0].ToString(), 2));
            }
            else
                return;


            Base_offscreen base_offscreen = new Base_offscreen(list);
            this.Hide();
            base_offscreen.ShowDialog();
            this.Close();

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

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
        Base_offscreen base_offscreen;
        String selectedLayout;

        public struct modules
        {
            public string name;
            public string location;
            public UserControl userControl;

            public modules(string name, string location)
            {
                this.name = name;
                this.location = location;
                userControl = null;
            }
        }

        public Start()
        {
            InitializeComponent();

            nrOfModules.SelectedIndex = Properties.Settings.Default.nrOfModules;
            selectedLayout = Properties.Settings.Default.selectedLayout;
            if (nrOfModules.SelectedIndex == 1 || nrOfModules.SelectedIndex == 2)
            {
                if(selectedLayout != null)
                    setPanel(selectedLayout);
            }
                

            contextMenuStrip.Items.Add("Jukebox");
            contextMenuStrip.Items.Add("Chat");
            contextMenuStrip.Items.Add("Ad_Image");
            contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
        }

        private void Start_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<modules> list = new List<modules>();

            foreach (ListBox listBox in box)
            {
                if (listBox.Items.Count <= 0)
                    return;
            }

            if (nrOfModules.SelectedItem.ToString() == "1" || nrOfModules.SelectedItem.ToString() == "4")
            {
                foreach (ListBox listBox in box)
                {
                    list.Add(new modules(listBox.Items[0].ToString(), listBox.Name));
                }
                base_offscreen = new Base_offscreen(list, nrOfModules.SelectedItem.ToString());
            }
            else
            {
                foreach (ListBox listBox in box)
                {
                    list.Add(new modules(listBox.Items[0].ToString(), listBox.Name));
                }
                base_offscreen = new Base_offscreen(list, picName);
            }

            
            this.Hide();

            //Save last used in settings
            Properties.Settings.Default.nrOfModules = nrOfModules.SelectedIndex;
            Properties.Settings.Default.Save();

            base_offscreen.ShowDialog();
            this.Close();
        }

        //Drag
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

        //Drop mouse icon
        private void listBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Drop
        private void listBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(
                    DataFormats.StringFormat);

               ((ListBox)sender).Items.Add(str);
            }
        }

        string picName;
        private void picBtn_Click(object sender, EventArgs e)
        {
            picName = ((Button)sender).Image.Tag.ToString();
            panel1.Controls.Clear();

            Properties.Settings.Default.selectedLayout = picName;
            setPanel(picName);
        }

        private void nrOfModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nr = ((ComboBox)sender).SelectedItem.ToString();
            panel1.Controls.Clear();

            switch (nr)
            {
                case "1":
                    picBtn1.Visible = false;
                    picBtn2.Visible = false;
                    picBtn3.Visible = false;
                    picBtn4.Visible = false;
                    setPanel(nr);
                    break;
                case "2":
                    picBtn1.Image = Properties.Resources.screen2_1;
                    picBtn1.Image.Tag = "2_1";
                    picBtn1.Visible = true;
                    picBtn2.Image = Properties.Resources.screen2_2;
                    picBtn2.Image.Tag = "2_2";
                    picBtn2.Visible = true;
                    picBtn3.Visible = false;
                    picBtn4.Visible = false;
                    break;
                case "3":
                    picBtn1.Image = Properties.Resources.screen3_1;
                    picBtn1.Image.Tag = "3_1";
                    picBtn1.Visible = true;
                    picBtn2.Image = Properties.Resources.screen3_2;
                    picBtn2.Image.Tag = "3_2";
                    picBtn2.Visible = true;
                    picBtn3.Image = Properties.Resources.screen3_3;
                    picBtn3.Image.Tag = "3_3";
                    picBtn3.Visible = true;
                    picBtn4.Image = Properties.Resources.screen3_4;
                    picBtn4.Image.Tag = "3_4";
                    picBtn4.Visible = true;
                    break;
                case "4":
                    picBtn1.Visible = false;
                    picBtn2.Visible = false;
                    picBtn3.Visible = false;
                    picBtn4.Visible = false;
                    setPanel(nr);
                    break;
            }

            if(box != null)
                CheckBoxes();
        }

        private SplitContainer split1;
        private SplitContainer split2;
        List<ListBox> box;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        private void setPanel(string pic)
        {
            box = new List<ListBox>();
            split1 = new SplitContainer();
            split2 = new SplitContainer();
            split1.BackColor = Color.White;
            split1.BorderStyle = split2.BorderStyle = BorderStyle.Fixed3D;

            for(int i = 0;i<int.Parse(nrOfModules.SelectedItem.ToString());i++)
            {
                box.Add(new ListBox());
                box[i].Name = "box" + i;
                box[i].ContextMenuStrip = contextMenuStrip;
                box[i].Dock = DockStyle.Fill;
                box[i].BorderStyle = BorderStyle.None;
            }

            switch (pic)
            {
                case "1":
                    panel1.Controls.Add(box[0]);
                    break;
                case "2_1":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split1.Orientation = Orientation.Horizontal;
                    split1.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    break;
                case "2_2":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split1.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    break;
                case "3_1":
                    split1.Panel1.Controls.Add(box[0]);
                    split2.Panel1.Controls.Add(box[1]);
                    split2.Panel2.Controls.Add(box[2]);
                    split1.Dock = DockStyle.Fill;                   
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split2.Dock = DockStyle.Fill;                   
                    panel1.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_2":
                    split1.Panel2.Controls.Add(box[0]);
                    split2.Panel1.Controls.Add(box[1]);
                    split2.Panel2.Controls.Add(box[2]);
                    split2.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_3":
                    split1.Panel2.Controls.Add(box[0]);
                    split2.Panel1.Controls.Add(box[1]);
                    split2.Panel2.Controls.Add(box[2]);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "3_4":
                    split1.Panel1.Controls.Add(box[0]);
                    split2.Panel1.Controls.Add(box[1]);
                    split2.Panel2.Controls.Add(box[2]);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "4":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split2.Panel1.Controls.Add(box[2]);
                    split2.Panel2.Controls.Add(box[3]);
                    split1.Width = panel1.Width;
                    split1.Height = panel1.Height / 2;
                    split2.Dock = DockStyle.Fill;
                    panel1.Controls.Add(split1);
                    panel1.Controls.Add(split2);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
            }
            split1.SplitterDistance = split1.Width / 2;

            if (box != null)
                CheckBoxes();
        }

        public void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ListBox temp = (ListBox)(((ContextMenuStrip)sender).SourceControl);

            foreach (ListBox boks in box)
            {
                if (boks.Items.Count > 0 && boks.Items[0].ToString() == e.ClickedItem.Text)
                    boks.Items.Clear();
            }

            if (temp.Items.Count > 0)
                temp.Items.Clear();
            temp.Items.Add(e.ClickedItem.Text);

            CheckBoxes();
        }

        public void CheckBoxes()
        {
            int boxes = 0;
            foreach (ListBox boks in box)
            {
                if (boks.Items.Count == 1)
                    boxes++;
            }

            if (boxes == int.Parse(nrOfModules.Text))
                btnStart.Enabled = true;
            else
                btnStart.Enabled = false;
        }
    }
}

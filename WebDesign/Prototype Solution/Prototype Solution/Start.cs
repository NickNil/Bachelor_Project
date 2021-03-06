﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseApplication
{
    public partial class Start : Form
    {
        Base_offscreen base_offscreen;
        String selectedLayout;
        string picName;
        private SplitContainer split1;
        private SplitContainer split2;
        List<ListBox> box;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        public Start()
        {
            InitializeComponent();

            //Try to load last used layout from Settings
            nrOfModules.SelectedIndex = Properties.Settings.Default.nrOfModules;
            selectedLayout = Properties.Settings.Default.selectedLayout;
            if (nrOfModules.SelectedIndex == 1 || nrOfModules.SelectedIndex == 2)
            {
                if (selectedLayout != null)
                {
                    setPanel(selectedLayout);
                    picName = selectedLayout;
                }
            }
                
            //Moduler
            contextMenuStrip.Items.Add("Jukebox");
            contextMenuStrip.Items.Add("Chat");
            contextMenuStrip.Items.Add("Bilde");

            contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
        }

        #region Private Methods

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<Module> list = new List<Module>();

            //Save content of each listbox in list and pass to Base_offscreen along with selected layout
            if (nrOfModules.SelectedItem.ToString() == "1" || nrOfModules.SelectedItem.ToString() == "4")
            {
                foreach (ListBox listBox in box)
                {
                    list.Add(new Module(listBox.Items[0].ToString(), listBox.Name));
                }
                base_offscreen = new Base_offscreen(list, nrOfModules.SelectedItem.ToString());
            }
            else
            {
                foreach (ListBox listBox in box)
                {
                    list.Add(new Module(listBox.Items[0].ToString(), listBox.Name));
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

        private void picBtn_Click(object sender, EventArgs e)
        {
            //Image.Tag is used to determine layout in setPanel()
            picName = ((Button)sender).Image.Tag.ToString();
            modulePanel.Controls.Clear();

            Properties.Settings.Default.selectedLayout = picName;
            setPanel(picName);
        }

        private void nrOfModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nr = ((ComboBox)sender).SelectedItem.ToString();
            modulePanel.Controls.Clear();

            //Show right layout images for number of modules selected
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

            if (box != null)
                CheckBoxes();
        }

        //Create mini layout for module selection
        private void setPanel(string pic)
        {
            box = new List<ListBox>();
            split1 = new SplitContainer();
            split2 = new SplitContainer();
            split1.BackColor = Color.White;
            split1.BorderStyle = split2.BorderStyle = BorderStyle.Fixed3D;

            //Create one listbox for each module
            for (int i = 0; i < int.Parse(nrOfModules.SelectedItem.ToString()); i++)
            {
                box.Add(new ListBox());
                box[i].Name = "box" + i;
                box[i].ContextMenuStrip = contextMenuStrip;
                box[i].Dock = DockStyle.Fill;
                box[i].BorderStyle = BorderStyle.None;
            }

            //Add listboxes to splitterpanels and splitcontainers to panel
            //pic determines layout based on image tag
            switch (pic)
            {
                case "1":
                    modulePanel.Controls.Add(box[0]);
                    break;
                case "2_1":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split1.Orientation = Orientation.Horizontal;
                    split1.Dock = DockStyle.Fill;
                    modulePanel.Controls.Add(split1);
                    break;
                case "2_2":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split1.Dock = DockStyle.Fill;
                    modulePanel.Controls.Add(split1);
                    break;
                case "3_1":
                    split1.Panel1.Controls.Add(box[0]);
                    split2.Panel1.Controls.Add(box[1]);
                    split2.Panel2.Controls.Add(box[2]);
                    split1.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split2.Dock = DockStyle.Fill;
                    modulePanel.Controls.Add(split1);
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
                    modulePanel.Controls.Add(split1);
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
                    modulePanel.Controls.Add(split1);
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
                    modulePanel.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "4":
                    split1.Panel1.Controls.Add(box[0]);
                    split1.Panel2.Controls.Add(box[1]);
                    split2.Panel1.Controls.Add(box[2]);
                    split2.Panel2.Controls.Add(box[3]);
                    split1.Width = modulePanel.Width;
                    split1.Height = modulePanel.Height / 2;
                    split2.Dock = DockStyle.Fill;
                    modulePanel.Controls.Add(split1);
                    modulePanel.Controls.Add(split2);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
            }
            split1.SplitterDistance = split1.Width / 2;

            if (box != null)
                CheckBoxes();
        }
        #endregion

        #region Public Methods

        public void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ListBox temp = (ListBox)(((ContextMenuStrip)sender).SourceControl);

            //Delete selected module from other listboxes
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

        //Check if every listbox contains 1 module, if true then enable Start button
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
        #endregion        
    }
}

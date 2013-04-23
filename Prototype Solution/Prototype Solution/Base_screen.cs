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
        SplitContainer split1, split2;
        List<Start.modules> modList;
        string layout;

        public Base_screen()
        {
            InitializeComponent();
        }

        public Base_screen(List<Start.modules> list, string layout)
        {
            InitializeComponent();
            modList = list;
            this.layout = layout;
        }

        private void Base_screen_Load(object sender, EventArgs e)
        {
            createLayout();       
        }

        private void control_Load(UserControl userControl, SplitterPanel location)
        {
            location.Controls.Add(userControl);
            userControl.Show(); 
        }

        private void createLayout()
        {
            split1 = new SplitContainer();
            split2 = new SplitContainer();
            split1.BackColor = Color.Transparent;
            split2.BackColor = Color.Transparent;
            split1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            split1.Resize += new System.EventHandler(this.splitContainer_Resize);
            split2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            split2.Resize += new System.EventHandler(this.splitContainer_Resize);
            split1.BorderStyle = split2.BorderStyle = BorderStyle.Fixed3D;
            

            switch (layout)
            {
                case "1":
                    UserControl temp = modList[0].userControl;
                    this.Controls.Add(temp);
                    temp.Show();
                    break;
                case "2_1":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    split1.Orientation = Orientation.Horizontal;
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    break;
                case "2_2":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    break;
                case "3_1":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split2.Panel1);
                    control_Load(modList[2].userControl, split2.Panel2);
                    split1.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split2.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_2":
                    control_Load(modList[0].userControl, split1.Panel2);
                    control_Load(modList[1].userControl, split2.Panel1);
                    control_Load(modList[2].userControl, split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_3":
                    control_Load(modList[0].userControl, split1.Panel2);
                    control_Load(modList[1].userControl, split2.Panel1);
                    control_Load(modList[2].userControl, split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "3_4":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split2.Panel1);
                    control_Load(modList[2].userControl, split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "4":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    control_Load(modList[2].userControl, split2.Panel1);
                    control_Load(modList[3].userControl, split2.Panel2);
                    split1.Width = this.Width;
                    split1.Height = this.Height / 2;
                    split2.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    this.Controls.Add(split2);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
            }
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SplitContainer tempContainer = (SplitContainer)sender;

            if(tempContainer.Panel1.Controls.Count > 0)
                tempContainer.Panel1.Controls[0].Size = new Size(tempContainer.Panel1.Width, tempContainer.Panel1.Height);
            if(tempContainer.Panel2.Controls.Count > 0)
                tempContainer.Panel2.Controls[0].Size = new Size(tempContainer.Panel2.Width, tempContainer.Panel2.Height);
        }

        private void splitContainer_Resize(object sender, EventArgs e)
        {
            SplitContainer tempContainer = (SplitContainer)sender;

            if (tempContainer.Panel1.Controls.Count > 0)
                tempContainer.Panel1.Controls[0].Size = new Size(tempContainer.Panel1.Width, tempContainer.Panel1.Height);
            if (tempContainer.Panel2.Controls.Count > 0)
                tempContainer.Panel2.Controls[0].Size = new Size(tempContainer.Panel2.Width, tempContainer.Panel2.Height);
        }

        private void Base_screen_Resize(object sender, EventArgs e)
        {
            if (this.Controls.Count == 1)
                this.Controls[0].Size = this.Size;
        }
    }
}

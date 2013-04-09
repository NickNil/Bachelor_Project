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
    }
}

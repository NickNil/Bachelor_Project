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
        NonFlickerSplitContainer split1, split2;
        List<Module> modList;
        string layout;

        public Base_screen()
        {
            InitializeComponent();
        }

        public Base_screen(List<Module> list, string layout)
        {
            InitializeComponent();
            modList = list;
            this.layout = layout;
        }

        #region Private Methods

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
            //Splitcontainer background is set to transparent
            split1 = new NonFlickerSplitContainer();
            split2 = new NonFlickerSplitContainer();
            split1.BackColor = Color.Transparent;
            split2.BackColor = Color.Transparent;
            split1.Panel1.Paint += Panel_Paint;
            split1.Panel2.Paint += Panel_Paint;
            split2.Panel1.Paint += Panel_Paint;
            split2.Panel2.Paint += Panel_Paint;
            split1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            split1.Resize += new System.EventHandler(this.splitContainer_Resize);
            split2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
            split2.Resize += new System.EventHandler(this.splitContainer_Resize);


            //control_Load receives 1 module from selectMods and 1 splitterpanel
            //and adds the module to the splitterpanel
            //splitcontainers are later added to splitcontainers and/or a panel
            //orientation is set based on layout
            switch (layout)
            {
                case "1":
                    UserControl temp = modList[0].userControl;
                    Panel layoutPanel = new Panel();
                    layoutPanel.BackColor = Color.Transparent;
                    layoutPanel.Resize += new System.EventHandler(this.layoutPanel_Resize);
                    layoutPanel.Dock = DockStyle.Fill;
                    layoutPanel.Controls.Add(temp);
                    splitContainer1.Panel2.Controls.Add(layoutPanel);
                    temp.Show();
                    break;
                case "2_1":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    split1.Orientation = Orientation.Horizontal;
                    split1.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(split1);
                    break;
                case "2_2":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    split1.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(split1);
                    break;
                case "3_1":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split2.Panel1);
                    control_Load(modList[2].userControl, split2.Panel2);
                    split1.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split2.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(split1);
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
                    splitContainer1.Panel2.Controls.Add(split1);
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
                    splitContainer1.Panel2.Controls.Add(split1);
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
                    splitContainer1.Panel2.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "4":
                    control_Load(modList[0].userControl, split1.Panel1);
                    control_Load(modList[1].userControl, split1.Panel2);
                    control_Load(modList[2].userControl, split2.Panel1);
                    control_Load(modList[3].userControl, split2.Panel2);
                    split1.Width = splitContainer1.Panel2.Width;
                    split1.Height = splitContainer1.Panel2.Height / 2;
                    split2.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(split1);
                    splitContainer1.Panel2.Controls.Add(split2);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
            }
        }

        void Panel_Paint(object sender, PaintEventArgs e)
        {
            //Draws custom border with reduced alpha value for partial transparency
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.FromArgb(50, 255, 255, 255), ButtonBorderStyle.Solid);
        }

        //Resizes splitterpanels controls[0] to parent size
        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            NonFlickerSplitContainer tempContainer = (NonFlickerSplitContainer)sender;

            if(tempContainer.Panel1.Controls.Count > 0)
                tempContainer.Panel1.Controls[0].Size = new Size(tempContainer.Panel1.Width, tempContainer.Panel1.Height);
            if(tempContainer.Panel2.Controls.Count > 0)
                tempContainer.Panel2.Controls[0].Size = new Size(tempContainer.Panel2.Width, tempContainer.Panel2.Height);
        }

        //Resizes splitterpanels controls[0] to parent size
        private void splitContainer_Resize(object sender, EventArgs e)
        {
            NonFlickerSplitContainer tempContainer = (NonFlickerSplitContainer)sender;

            if (tempContainer.Panel1.Controls.Count > 0)
                tempContainer.Panel1.Controls[0].Size = new Size(tempContainer.Panel1.Width, tempContainer.Panel1.Height);
            if (tempContainer.Panel2.Controls.Count > 0)
                tempContainer.Panel2.Controls[0].Size = new Size(tempContainer.Panel2.Width, tempContainer.Panel2.Height);
        }

        //Resizes panel controls[0] to parent size
        private void layoutPanel_Resize(object sender, EventArgs e)
        {
            Panel tempPanel = (Panel)sender;

            if (tempPanel.Controls.Count > 0)
            {
                tempPanel.Controls[0].Size = tempPanel.Size;
            }
        }
        #endregion
    }
}

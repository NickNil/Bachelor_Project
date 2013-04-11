using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using WMPLib;

namespace Prototype_Solution
{
    public partial class Base_offscreen : Form
    {
        Base_screen base_screen;
        //public Jukebox jukebox;
        public Chat chat;
        public Ad_Image ad_image;
        List<Start.modules> modList;
        SplitContainer split1, split2;
        string layout;
        Connection connection;

        public Base_offscreen()
        {
            InitializeComponent();
        }
        public Base_offscreen(List<Start.modules> list, string layout)
        {
            InitializeComponent();
            modList = list;
            this.layout = layout;
        }

        private void Base_offscreen_Load(object sender, EventArgs e)
        {
            createLayout();                      

            //Base_screen
            base_screen = new Base_screen(modList, layout);
            base_screen.Show();
        }

        private UserControl selectMods(Start.modules item, int nr)
        {
            UserControl temp;
            /*if (item.name.Equals("Jukebox"))
            {
                jukebox = new Jukebox();
                item.userControl = jukebox.jb_screen;
                temp = jukebox.jb_offscreen;
            }
            else */if (item.name.Equals("Chat"))
            {
                chat = new Chat();
                item.userControl = chat.chat_screen;
                temp = chat.chat_offscreen;
            }
            else
            {
                ad_image = new Ad_Image();
                item.userControl = ad_image.ad_image_screen;
                temp = ad_image.ad_image_offscreen;
            }
            modList[nr] = item;
             connection = new Connection(chat.chat_screen);
            return temp;
        }

        private void createLayout()
        {
            split1 = new SplitContainer();
            split2 = new SplitContainer();
            split1.BorderStyle = split2.BorderStyle = BorderStyle.Fixed3D;

            switch (layout)
            {
                case "1":
                    UserControl temp = selectMods(modList[0], 0); 
                    this.Controls.Add(temp);
                    temp.Show();
                    break;
                case "2_1":
                    control_Load(selectMods(modList[0], 0), split1.Panel1);
                    control_Load(selectMods(modList[1], 1), split1.Panel2);
                    split1.Orientation = Orientation.Horizontal;
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    break;
                case "2_2":
                    control_Load(selectMods(modList[0], 0), split1.Panel1);
                    control_Load(selectMods(modList[1], 1), split1.Panel2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    break;
                case "3_1":
                    control_Load(selectMods(modList[0], 0), split1.Panel1);
                    control_Load(selectMods(modList[1], 1), split2.Panel1);
                    control_Load(selectMods(modList[2], 2), split2.Panel2);
                    split1.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split2.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_2":
                    control_Load(selectMods(modList[0], 0), split1.Panel2);
                    control_Load(selectMods(modList[1], 1), split2.Panel1);
                    control_Load(selectMods(modList[2], 2), split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split1.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
                case "3_3":
                    control_Load(selectMods(modList[0], 0), split1.Panel2);
                    control_Load(selectMods(modList[1], 1), split2.Panel1);
                    control_Load(selectMods(modList[2], 2), split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel1.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "3_4":
                    control_Load(selectMods(modList[0], 0), split1.Panel1);
                    control_Load(selectMods(modList[1], 1), split2.Panel1);
                    control_Load(selectMods(modList[2], 2), split2.Panel2);
                    split2.Dock = DockStyle.Fill;
                    split2.Orientation = Orientation.Horizontal;
                    split1.Panel2.Controls.Add(split2);
                    split1.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    split2.SplitterDistance = split2.Height / 2;
                    break;
                case "4":
                    control_Load(selectMods(modList[0], 0), split1.Panel1);
                    control_Load(selectMods(modList[1], 1), split1.Panel2);
                    control_Load(selectMods(modList[2], 2), split2.Panel1);
                    control_Load(selectMods(modList[3], 3), split2.Panel2);
                    split1.Width = this.Width;
                    split1.Height = this.Height / 2;
                    split2.Dock = DockStyle.Fill;
                    this.Controls.Add(split1);
                    this.Controls.Add(split2);
                    split2.SplitterDistance = split2.Width / 2;
                    break;
            }
        }

        private void control_Load(UserControl userControl, SplitterPanel location)
        {
            location.Controls.Add(userControl);
            userControl.Show(); 
        }
    }
}

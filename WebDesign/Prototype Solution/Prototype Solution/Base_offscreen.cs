using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Prototype_Solution
{
    public partial class Base_offscreen : Form
    {
        Base_screen base_screen;
        public Jukebox jukebox;
        public Chat chat;
        public Ad_Image ad_image;
        List<Module> modList;
        NonFlickerSplitContainer split1, split2;
        string layout;
        TCP_Server connection;
        public static List<string> blackList = new List<string>();

        public Base_offscreen()
        {
            InitializeComponent();
        }

        public Base_offscreen(List<Module> list, string layout)
        {
            InitializeComponent();
            modList = list;
            this.layout = layout;
        }

        #region Private Methods

        private void Base_offscreen_Load(object sender, EventArgs e)
        {
            chat = null;
            jukebox = null;
            ad_image = null;



            createLayout();

            connection = new TCP_Server(chat, jukebox);

            //Base_screen
            base_screen = new Base_screen(modList, layout);
            base_screen.Show();
        }

        private UserControl selectMods(Module item, int nr)
        {
            UserControl temp;
            if (item.name.Equals("Jukebox"))
            {
                jukebox = new Jukebox();
                item.userControl = jukebox.jb_screen;
                temp = jukebox.jb_offscreen;
            }
            else if (item.name.Equals("Chat"))
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

            return temp;
        }

        private void createLayout()
        {
            split1 = new NonFlickerSplitContainer();
            split2 = new NonFlickerSplitContainer();
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
                    UserControl temp = selectMods(modList[0], 0);
                    Panel layoutPanel = new Panel();
                    layoutPanel.BackColor = Color.Transparent;
                    layoutPanel.Resize += new System.EventHandler(this.layoutPanel_Resize);
                    layoutPanel.Dock = DockStyle.Fill;
                    layoutPanel.Controls.Add(temp);
                    this.Controls.Add(layoutPanel);
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

        private void layoutPanel_Resize(object sender, EventArgs e)
        {
            Panel tempPanel = (Panel)sender;

            if (tempPanel.Controls.Count > 0)
            {
                tempPanel.Controls[0].Size = tempPanel.Size;
            }
        }

        private void control_Load(UserControl userControl, SplitterPanel location)
        {
            location.Controls.Add(userControl);
            userControl.Show();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SplitContainer tempContainer = (SplitContainer)sender;

            if (tempContainer.Panel1.Controls.Count > 0)
                tempContainer.Panel1.Controls[0].Size = new Size(tempContainer.Panel1.Width, tempContainer.Panel1.Height);
            if (tempContainer.Panel2.Controls.Count > 0)
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

        #endregion

        #region Public Methods

        public static bool CheckBlacklist(string ip)
        {
            if (blackList.Contains(ip))
                return true;
            return false;
        }
        #endregion
    }
}

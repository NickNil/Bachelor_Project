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
        List<Start.modules> modList;
        List<SplitterPanel> container = new List<SplitterPanel>();
       

        public Base_offscreen()
        {
            InitializeComponent();
        }
        public Base_offscreen(List<Start.modules> list)
        {
            InitializeComponent();
            modList = list;           
        }

        private void Base_offscreen_Load(object sender, EventArgs e)
        {
            container.Add(splitContainer2.Panel1);
            container.Add(splitContainer2.Panel2);
            container.Add(splitContainer1.Panel2);

            for (int i = 0; i < modList.Count; i++)
            {
                Start.modules item = modList[i];

                if (item.name.Equals("Jukebox"))
                {
                    jukebox = new Jukebox();
                    control_Load(jukebox.jb_offscreen, container[item.location]);
                    item.userControl = jukebox.jb_screen;
                }
                else if (item.name.Equals("Chat"))
                {
                    chat = new Chat();
                    control_Load(chat.chat_offscreen, container[item.location]);
                    item.userControl = chat.chat_screen;
                }
                else if (item.name.Equals("Ad_Image"))
                {
                    ad_image = new Ad_Image();
                    control_Load(ad_image.ad_image_offscreen, container[item.location]);
                    item.userControl = ad_image.ad_image_screen;
                }
                modList[i] = item;
            }

            

            //Base_screen
            base_screen = new Base_screen(modList);
            base_screen.Show();
        }

        private void control_Load(UserControl userControl, SplitterPanel location)
        {
            location.Controls.Add(userControl);
            userControl.Show(); 
        }
    }
}

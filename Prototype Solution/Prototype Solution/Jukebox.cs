using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    public class Jukebox
    {
        Base_offscreen base_offscreen;
        public JB_offscreen jb_offscreen;
        public JB_screen jb_screen;

        public Jukebox()
        {
            InitializeComponent();
        }
        public Jukebox(Base_offscreen frm)
        {
            InitializeComponent();
            base_offscreen = frm;
            jb_screen = new JB_screen();
            jb_offscreen = new JB_offscreen(jb_screen);
            
        }

        private void InitializeComponent()
        {
            
        }
    }
}

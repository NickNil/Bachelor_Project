using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApplication
{
    public class Jukebox
    {
        public JB_offscreen jb_offscreen;
        public JB_screen jb_screen;

        public Jukebox()
        {
            InitializeComponent();
            jb_screen = new JB_screen();
            jb_offscreen = new JB_offscreen(jb_screen);
            
        }

        private void InitializeComponent()
        {
            
        }
    }
}

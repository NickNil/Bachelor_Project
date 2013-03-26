using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype
{
    public class Jukebox
    {
        Base_offscreen form1;
        public JBplayer jbPlayer;
        public FormJB formJB;

        public Jukebox(Base_offscreen frm)
        {
            InitializeComponent();
            form1 = frm;
            formJB = new FormJB();
            jbPlayer = new JBplayer(formJB);
            
        }

        private void InitializeComponent()
        {
            
        }
    }
}

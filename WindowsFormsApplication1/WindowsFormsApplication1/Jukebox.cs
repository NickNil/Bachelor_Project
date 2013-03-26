using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Jukebox
    {
        Form1 form1;
        public JBplayer jbPlayer;
        public FormJB formJB;

        public Jukebox(Form1 frm)
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

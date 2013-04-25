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
    public partial class JB_screen : UserControl
    {

        public JB_screen()
        {
            InitializeComponent();
            
            //Reduce flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                               ControlStyles.UserPaint |
                               ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void JB_screen_Resize(object sender, EventArgs e)
        {
            label1.Height = this.Parent.Height - textNowP.Height;
        }
    }
}

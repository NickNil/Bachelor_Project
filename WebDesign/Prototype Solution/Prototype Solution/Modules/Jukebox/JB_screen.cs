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

            textNowP.Paint += textNowP_Paint;
        }

        void textNowP_Paint(object sender, PaintEventArgs e)
        {
            Rectangle borderRectangle = textNowP.ClientRectangle;
            borderRectangle.Height = 2;

            ControlPaint.DrawBorder(e.Graphics, borderRectangle, Color.FromArgb(50, 255, 255, 255), ButtonBorderStyle.Solid);
        }

        private void JB_screen_Resize(object sender, EventArgs e)
        {
            labelSongs.Height = this.Parent.Height - textNowP.Height;
        }
    }
}

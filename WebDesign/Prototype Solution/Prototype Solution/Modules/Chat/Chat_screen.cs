using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseApplication
{
    public partial class Chat_screen : UserControl
    {
        public Chat_screen()
        {
            InitializeComponent();

        }

        #region Private Methods

        private void Chat_screen_Resize(object sender, EventArgs e)
        {
            this.Controls[0].Size = this.Size;
        }
        #endregion
    }
}

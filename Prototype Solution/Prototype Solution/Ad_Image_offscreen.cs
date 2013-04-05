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
    public partial class Ad_Image_offscreen : Form
    {
        Ad_Image_screen ad_image_screen;

        public Ad_Image_offscreen(Ad_Image_screen frm)
        {
            InitializeComponent();
            ad_image_screen = frm;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ShowDialog();

            ad_image_screen.pictureBox.ImageLocation = fileDialog.FileName;
        }
    }
}

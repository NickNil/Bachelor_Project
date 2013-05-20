using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Prototype_Solution
{
    public partial class Ad_Image_offscreen : UserControl
    {
        List<string> images;
        Ad_Image_screen ad_image_screen;
        Timer timer;
        int nextImage;

        public Ad_Image_offscreen(Ad_Image_screen ad_image_screen)
        {
            InitializeComponent();
            this.ad_image_screen = ad_image_screen;
            images = new List<string>();
            timer = new Timer();
            labelSlider.Text = "Hastighet: " + sliderTime.Value + " min";
        }

        #region Private Methods

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;

            StringBuilder allImageExtensions = new StringBuilder();
            string separator = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                allImageExtensions.Append(separator);
                allImageExtensions.Append(codec.FilenameExtension);
                separator = ";";
            }
            fileDialog.Filter = "All Image Files|" + allImageExtensions;
            
            fileDialog.ShowDialog();

            timer.Stop();
            images.Clear();
            nextImage = 1;
            images.AddRange(fileDialog.FileNames);

            if (images.Count > 0)
            {
                ad_image_screen.pictureBox.ImageLocation = images[0];
                if (images.Count > 1)
                    startTimer();
            }   
        }

        private void startTimer()
        {
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = 60000 * Math.Max(1, sliderTime.Value); // Timer will tick every 1 minute * sliderTime to min 1 minute
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (nextImage >= images.Count)
                nextImage = 0;

            ad_image_screen.pictureBox.ImageLocation = images[nextImage];
            nextImage++;
        }        

        private void sliderTime_ValueChanged(object sender, EventArgs e)
        {
            labelSlider.Text = "Hastighet: " + Math.Max(1, sliderTime.Value) + " min";
            timer.Interval = 60000 * Math.Max(1, sliderTime.Value);
        }
        #endregion
    }
}

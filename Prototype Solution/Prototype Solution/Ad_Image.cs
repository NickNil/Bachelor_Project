using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Solution
{
    public class Ad_Image
    {
        public Ad_Image_screen ad_image_screen;
        public Ad_Image_offscreen ad_image_offscreen;

        public Ad_Image()
        {
            ad_image_screen = new Ad_Image_screen();
            ad_image_offscreen = new Ad_Image_offscreen(ad_image_screen);
            
        }
    }
}

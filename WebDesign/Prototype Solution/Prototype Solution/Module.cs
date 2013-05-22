using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseApplication
{
    public class Module
    {
        public string name;
        public string location;
        public UserControl userControl;

        public Module(string name, string location)
        {
            this.name = name;
            this.location = location;
            userControl = null;
        }
    }
}

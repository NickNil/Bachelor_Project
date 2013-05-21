using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Prototype_Solution
{
    public partial class NonFlickerSplitContainer : SplitContainer
    {
        public NonFlickerSplitContainer()
        {
            //Ignore paint background, control paints itself and doublebuffer is optimized
            //Reduces flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                               ControlStyles.UserPaint |
                               ControlStyles.OptimizedDoubleBuffer, true);

            MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

            object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                                                ControlStyles.UserPaint |
                                                               ControlStyles.OptimizedDoubleBuffer, true };

            //Splitterpanels SetStyle control is set to mirror that of parent container
            objMethodInfo.Invoke(this.Panel1, objArgs);
            objMethodInfo.Invoke(this.Panel2, objArgs);
        }
    }
}

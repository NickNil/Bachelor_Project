using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WebDesign;

namespace WindowsFormsApplication1
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            for (int i = 0; i < 300; i++)
            {
                Thread t = new Thread(new ThreadStart(timer_Tick));
                t.Start();
            }                         
        }

     
        void timer_Tick()
        {
            int i = Thread.CurrentThread.ManagedThreadId;
            TCP_Client test;
            Random rand = new Random();
            while (true)
            {
                Thread.Sleep(rand.Next(3000, 5000));
                test = new TCP_Client();

                test.Send("IP=[" + i + "]Chat=Test" + i + ": Testing");

               // test.Send("IP=[" + i + "]Jukebox=0: Sleep Away");
            }
        }
    }
}

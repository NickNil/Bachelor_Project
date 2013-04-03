using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Prototype_Solution
{
    public partial class JB_offscreen : Form
    {
        Timer timer = new Timer();
        List<string> songs = new List<string>();
        JB_screen jb_screen;
        WMPLib.IWMPControls3 mediaP_controls;

        public JB_offscreen()
        {
            InitializeComponent();
        }
        
        public JB_offscreen(JB_screen frm)
        {
            InitializeComponent();

            jb_screen = frm;
            mediaP_controls = (WMPLib.IWMPControls3)mediaP.Ctlcontrols;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Stop();
        }

        private void JB_offscreen_Load(object sender, EventArgs e)
        {

        }

        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                mediaP.URL = songs[0].ToString();
                string tempItem = songs[0].ToString();
                songs.RemoveAt(0);
                songs.Add(tempItem);
                timer.Stop();
                updateTxt();
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.ShowDialog();

            songs.Clear();
            foreach (string name in fileDialog.FileNames)
            {
                songs.Add(name);
            }
            updateTxt();
        }

        private void mediaP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (mediaP_controls.currentItem != null)
            {
                jb_screen.textNowP.Text = (mediaP_controls.currentItem.getItemInfo("Title") + " - " +
                    mediaP_controls.currentItem.getItemInfo("Artist"));
                Console.WriteLine("derp");
            }      

            if (mediaP.playState == WMPPlayState.wmppsMediaEnded)
            {
               
                if (songs.Count > 0)
                {
                    timer.Start();
                }
            }
        }

        public void updateTxt()
        {
            listBox_songs.DataSource = null;
            listBox_songs.DataSource = songs;
            jb_screen.listBox_songs.DataSource = null;
            jb_screen.listBox_songs.DataSource = songs;

           
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Check first to be sure the operation is valid.
            if (mediaP_controls.get_isAvailable("play"))
            {
                mediaP_controls.play();
            } 
            
            else if (songs.Count > 0)
            {
                mediaP.URL = songs[0].ToString();
                string tempItem = songs[0].ToString();
                songs.RemoveAt(0);
                songs.Add(tempItem);
                updateTxt();
            }

            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            
            // Check first to be sure the operation is valid.
            if (mediaP_controls.get_isAvailable("pause"))
            {
                mediaP_controls.pause();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Check first to be sure the operation is valid.
            if (mediaP_controls.get_isAvailable("stop"))
            {
                mediaP_controls.stop();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            // Check first to be sure the operation is valid.
            if (mediaP_controls.get_isAvailable("previous"))
            {
                mediaP_controls.previous();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            /*
            WMPLib.IWMPControls3 mediaP_controls = (WMPLib.IWMPControls3)mediaP.Ctlcontrols;
            // Check first to be sure the operation is valid.
            if (controls.get_isAvailable("next"))
            {
                controls.next();
            }*/

            if (songs.Count > 0)
            {
                mediaP.URL = songs[0].ToString();
                string tempItem = songs[0].ToString();
                songs.RemoveAt(0);
                songs.Add(tempItem);
                updateTxt();
            }
        }
    }
}

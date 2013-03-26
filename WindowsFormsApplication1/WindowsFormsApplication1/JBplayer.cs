using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Prototype
{
    public partial class JBplayer : Form
    {
        Timer timer = new Timer();
        List<string> songs = new List<string>();
        FormJB formJB;
        
        public JBplayer(FormJB frm)
        {
            InitializeComponent();

            formJB = frm;
            
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Stop();
        }

        private void JBplayer_Load(object sender, EventArgs e)
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
                throw er;
            }
        }
        private void button1_Click(object sender, EventArgs e)
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
   
        private void button2_Click(object sender, EventArgs e)
        {
            mediaP.URL = songs[0].ToString();
            string tempItem = songs[0].ToString();
            songs.RemoveAt(0);
            songs.Add(tempItem);
            updateTxt();
        }

        private void mediaP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (mediaP.playState == WMPPlayState.wmppsMediaEnded)
            {
                if (songs.Count > 0)
                    timer.Start();                  
            }
        }

        public void updateTxt()
        {
            richTextBox1.Clear();
            richTextBox1.Lines = songs.ToArray();

            formJB.richTextBox1.Lines = richTextBox1.Lines;

            for (int i = 0; i < formJB.richTextBox1.Lines.Length; i++)
            {
               formJB.richTextBox1.Lines[i] = formJB.richTextBox1.Lines[i].Substring(8);
            }

            //formJB.richTextBox1.Lines = richTextBox1.Lines.;
        }

        private void mediaP_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

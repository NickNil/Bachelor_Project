using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.IO;

namespace Prototype_Solution
{
    public partial class JB_offscreen : UserControl
    {
        Timer timer = new Timer();
        List<Song> songs = new List<Song>();
        public List<string> songs2 = new List<string>();
        JB_screen jb_screen;
        WMPLib.IWMPControls3 mediaP_controls;

        public JB_offscreen()
        {
            InitializeComponent();
        }
        
        public JB_offscreen(JB_screen jb_screen)
        {
            InitializeComponent();

            this.jb_screen = jb_screen;
            this.jb_screen.Resize += new System.EventHandler(this.JB_screen_Resize);
            mediaP_controls = (WMPLib.IWMPControls3)mediaP.Ctlcontrols;

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Stop();
        }

        #region Private Methods

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                mediaP.URL = songs[0].ToString();
                string tempItem = songs[0].ToString();
                songs.RemoveAt(0);
                songs.Add(new Song(tempItem));
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
            fileDialog.Filter = "Music(*.mp3)|*.mp3";
            fileDialog.ShowDialog();

            songs.Clear();
            foreach (string name in fileDialog.FileNames)
            {
                songs.Add(new Song(name));
            }
            updateTxt();
        }

        private void mediaP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (mediaP_controls.currentItem != null)
            {
                if (mediaP_controls.get_isAvailable("stop"))
                {
                    jb_screen.textNowP.Text = ("Now Playing: " + mediaP_controls.currentItem.getItemInfo("Title") + " - " +
                        mediaP_controls.currentItem.getItemInfo("Artist"));
                }
                else
                    jb_screen.textNowP.Text = "Now Playing: ";
            }      

            if (mediaP.playState == WMPPlayState.wmppsMediaEnded)
            {
               
                if (songs.Count > 0)
                {
                    timer.Start();
                }
            }
        }

        #region MediaPlayer Buttons
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
                songs.Add(new Song(tempItem));
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
                songs.Add(new Song(tempItem));
                updateTxt();
            }
        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Jukebox(*.itp)|*.itp";
            fileDialog.ShowDialog();

            if(fileDialog.FileName != string.Empty)
                LoadPlaylist(fileDialog.FileName);
        }

        private void LoadPlaylist(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string line;
                    songs.Clear();
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        songs.Add(new Song(line));
                    }
                    updateTxt();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "Playlist.itp";
            fileDialog.Filter = "Jukebox(*.itp)|*.itp";
            fileDialog.ShowDialog();

            List<string> temp = new List<string>();
            for (int i = 0; i < songs.Count; i++)
                temp.Add(songs[i].ToString());

            string name = fileDialog.FileName;
            File.WriteAllLines(name, temp);
        }

        private void listBox_songs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (songs.Count > 0)
                {
                    songs.RemoveAt(listBox_songs.SelectedIndex);
                    updateTxt();
                }
            }
        }

        private void JB_screen_Resize(object sender, EventArgs e)
        {
            Size textSize = TextRenderer.MeasureText("text", jb_screen.labelSongs.Font);
            int maxLines = ((jb_screen.Height - jb_screen.textNowP.Height) / textSize.Height);

            if (songs2.Count > maxLines)
            {
                StringBuilder stringB = new StringBuilder();

                foreach (string str in songs2.GetRange(0, maxLines))
                {
                    stringB.Append(str + "\n");
                }
                jb_screen.labelSongs.Text = stringB.ToString();
            }
        }
        #endregion

        #region Public Methods

        public void updateTxt()
        {
            songs2 = new List<string>();

            //Remove file path & file extension
            for (int i = 0; i < songs.Count; i++)
            {
                //Remove path
                songs[i].name = songs[i].path.Substring(songs[i].path.LastIndexOf("\\") + 1, songs[i].path.LastIndexOf(".") - 1 - songs[i].path.LastIndexOf("\\"));

                songs[i].name = songs[i].name.Replace("_", " ");

                songs2.Add(songs[i].votes + ": " + songs[i].name);
            }

            updateLocal();
        }

        public void updateLocal()
        {
            if (jb_screen.labelSongs.InvokeRequired)
            {
                jb_screen.labelSongs.Invoke(new MethodInvoker(updateLocal));
                return;
            }

            StringBuilder stringB = new StringBuilder();

            Size textSize = TextRenderer.MeasureText("text", jb_screen.labelSongs.Font);

            int maxLines = ((jb_screen.Height - jb_screen.textNowP.Height) / textSize.Height);
            
            listBox_songs.DataSource = null;
            listBox_songs.DataSource = songs2;

            if (songs2.Count > maxLines)
            {
                foreach (string str in songs2.GetRange(0, maxLines))
                {
                    stringB.Append(str + "\n");
                }
                jb_screen.labelSongs.Text = stringB.ToString();
            }
            else
            {
                foreach (string str in songs2)
                {
                    stringB.Append(str + "\n");
                }
                jb_screen.labelSongs.Text = stringB.ToString();
            }
        }

        public void Vote(string name)
        {
            foreach (Song song in songs)
                song.newVote(name);
            songs.Sort(delegate(Song s1, Song s2) { return s2.votes.CompareTo(s1.votes); }); ;
            updateTxt();

        }
        #endregion
    }
}

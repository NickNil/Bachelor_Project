using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDesign
{
    public partial class Jukebox : System.Web.UI.Page
    {
        TCP_Client c;
        string playlistString;
        List<string> playList = new List<string>();

        int i;
        string song, voteInput;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (c == null)
                c = new TCP_Client();
            if (songList.Items.Count == 0)
            {
                c.Send("Jukebox=Page Load");
                createList();
            }

        }

        protected void createList()
        {
            playlistString = c.ReceiveDataFromServer();
            if (playlistString != null)
            {
                playList.Clear();
                songList.Items.Clear();
                while (playlistString.IndexOf(";;") != -1)
                {
                    i = playlistString.IndexOf(";;");
                    song = playlistString.Substring(0, i);
                    playList.Add(song);
                    playlistString = playlistString.Remove(0, i + 2);
                }
                foreach (string s in playList)
                    songList.Items.Add(s);
            }       
        }

        protected void voteBtn_Click(object sender, EventArgs e)
        {
            voteInput = "Jukebox=" + songList.SelectedItem;
            c.Send(voteInput);

            //Receive updated list

            createList();
        }

        protected void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            voteBtn.Enabled = true;
        }
    }
}
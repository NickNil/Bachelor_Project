using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPWeb2
{
    public partial class Jukebox : System.Web.UI.Page
    {
        Connection_C c;
        string playlistString;
        List<string> playList = new List<string>();

        int i;
        string song, voteInput;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (c == null)
                c = new Connection_C();
            if (songList.Items.Count == 0)
                createList();
            
        }

        protected void createList()
        {
            c.Send("Jukebox=Page Load");
            c.ReceiveDataFromServer();
            playlistString = c.receivedData;
            if (playlistString != null)
            {
                while (playlistString.IndexOf("\n") != -1)
                {
                    i = playlistString.IndexOf("\n");
                    song = playlistString.Substring(0, i);
                    playList.Add(song);
                    playlistString = playlistString.Remove(0, i + 1);
                }
                foreach (string s in playList)
                    songList.Items.Add(s);
            }
        }

        protected void voteBtn_Click(object sender, EventArgs e)
        {
            voteInput = "Jukebox=" + songList.SelectedItem;
            c.Send(voteInput);
        }

        protected void songList_SelectedIndexChanged(object sender, EventArgs e)
        {
            voteBtn.Enabled = true;
        }

    }
}
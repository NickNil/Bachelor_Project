using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    /// <summary>
    /// Contains song name, path and number of votes.
    /// </summary>
    public class Song 

    {
        public string path, name;
        public int votes = 0;

        public Song(string s)
        {
            path = s;
        }

        public override string ToString()
        {
            return path;
        }

        public void newVote(string s)
        {
            if (s.Remove(0,3) == name)
            {
                votes++;
                //MessageBox.Show("vote recieved for " + s);
            }
        }
    }

}

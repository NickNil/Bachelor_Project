using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApplication
{
    /// <summary>
    /// Contains text to be written and IP address of sender.
    /// </summary>
    public class ChatText
    {
        public string text;
        public string ip;

        public ChatText(string text, string ip)
            {
                this.text = text;
                this.ip = ip;
            }

        /// <summary>
        /// Returns text
        /// </summary>
        public override string ToString()
        {
            return text;
        }
            
    }
}

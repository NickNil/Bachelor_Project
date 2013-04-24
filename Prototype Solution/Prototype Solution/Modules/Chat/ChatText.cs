using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Solution
{
    public class ChatText
    {
        public string text;
        public string ip;

        public ChatText(string text, string ip)
            {
                this.text = text;
                this.ip = ip;
            }

        public override string ToString()
        {
            return text;
        }
            
    }
}

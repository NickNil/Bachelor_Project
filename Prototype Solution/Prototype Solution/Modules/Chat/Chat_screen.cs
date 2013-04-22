using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    public partial class Chat_screen : UserControl
    {
        int maxLines;
        List<string> chatList;
        delegate void SetTextCallback(string text);

        public Chat_screen()
        {
            InitializeComponent();
            chatList = new List<string>();
            maxLines = this.Size.Height / textChat.Font.Height;
            Console.WriteLine(maxLines);
        }

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.textChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.WriteText(text);
            }
        }

        public void WriteText(string text)
        {
            //Auto scroll
            maxLines = (panel1.Parent.Parent.Height / textChat.Font.Height);
            if (chatList.Count >= maxLines)
                chatList.RemoveAt(0);
            chatList.Add(text);

            textChat.Text = String.Empty;
            foreach (string str in chatList)
                textChat.Text += str + "\n";
        }
    }
}

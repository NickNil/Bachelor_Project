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
        const int MAX = 100;
        List<string> chatList;
        delegate void SetTextCallback(string text);

        public Chat_screen()
        {
            InitializeComponent();
            chatList = new List<string>();
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
            if (text == String.Empty)
                return;

            //New line
            Size textSize = TextRenderer.MeasureText(text, textChat.Font);
            if (textSize.Width > Width)
            {
                WriteText(text.Substring(0, text.Length / 2));
                WriteText(text.Substring(text.Length / 2));
                return;
            }

            //Auto scroll
            int maxLines = (Height / textSize.Height);
            while (chatList.Count >= MAX)
                chatList.RemoveAt(0);
            chatList.Add(text);

            textChat.Text = String.Empty;
            if (chatList.Count > maxLines)
                foreach (string str in chatList.GetRange(chatList.Count - maxLines, maxLines))
                    textChat.Text += str + "\n";
            else
                foreach (string str in chatList)
                    textChat.Text += str + "\n";
        }

        private void Chat_screen_Resize(object sender, EventArgs e)
        {
            Size textSize = TextRenderer.MeasureText("blah", textChat.Font);
            int maxLines = (Height / textSize.Height);
            textChat.Text = String.Empty;
            if (chatList.Count > maxLines)
                foreach (string str in chatList.GetRange(chatList.Count - maxLines, maxLines))
                    textChat.Text += str + "\n";
            else
                foreach (string str in chatList)
                    textChat.Text += str + "\n";
        }
    }
}

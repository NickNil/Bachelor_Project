using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    public partial class Chat_offscreen : UserControl
    {
        const int MAX = 100;
        delegate void SetTextCallback(string text, string ip);
        Chat_screen chat_screen;
        ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

        public Chat_offscreen()
        {
            InitializeComponent();
        }

        public Chat_offscreen(Chat_screen chat_screen)
        {
            InitializeComponent();
            this.chat_screen = chat_screen;
            this.chat_screen.Resize += new System.EventHandler(this.Chat_screen_Resize);

            listBoxChat.ContextMenuStrip = contextMenuStrip;
            contextMenuStrip.Items.Add("Delete");
            contextMenuStrip.Items.Add("Ban IP");
            contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(contextMenuStrip_ItemClicked);
        }

        #region Public Methods

        public void SetText(string text, string ip)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (chat_screen.textChat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text, ip });
            }
            else
            {
                this.WriteText(text, ip);
            }
        }

        public void WriteText(string text, string ip)
        {
            if (text == String.Empty)
                return;

            //If text.width > screen.width then split text at center and try again
            Size textSize = TextRenderer.MeasureText(text, chat_screen.textChat.Font);
            if (textSize.Width > chat_screen.Width)
            {
                WriteText(text.Substring(0, text.Length / 2), ip);
                WriteText(text.Substring(text.Length / 2), ip);
                return;
            }

            //Auto scroll
            int maxLines = (chat_screen.Height / textSize.Height);
            while (listBoxChat.Items.Count >= MAX)
                listBoxChat.Items.RemoveAt(0);
            listBoxChat.Items.Add(new ChatText(text, ip));

            chat_screen.textChat.Text = String.Empty;
            if (listBoxChat.Items.Count > maxLines)
            {
                for(int i = listBoxChat.Items.Count - maxLines; i < listBoxChat.Items.Count; i++)
                {
                    chat_screen.textChat.Text += ((ChatText)listBoxChat.Items[i]).text + "\n";
                }
            }
            else
                foreach (ChatText str in listBoxChat.Items)
                    chat_screen.textChat.Text += str.text + "\n";
        }
        #endregion

        #region Private Methods

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ChatText test = (ChatText)(((ListBox)(((ContextMenuStrip)sender).SourceControl)).SelectedItem);
            if (e.ClickedItem.Text == "Delete")
                throw new NotImplementedException();
            else if (e.ClickedItem.Text == "Ban IP")
            {
                if (!Base_offscreen.CheckBlacklist(test.ip))
                    Base_offscreen.blackList.Add(test.ip);
            }
        }

        private void Chat_screen_Resize(object sender, EventArgs e)
        {
            //Get height of font
            Size textSize = TextRenderer.MeasureText("blah", chat_screen.textChat.Font);
            int maxLines = (chat_screen.Height / textSize.Height);
            chat_screen.textChat.Text = String.Empty;
            if (listBoxChat.Items.Count > maxLines)
            {
                for (int i = listBoxChat.Items.Count - maxLines; i < listBoxChat.Items.Count; i++)
                {
                    chat_screen.textChat.Text += ((ChatText)listBoxChat.Items[i]).text + "\n";
                }
            }
            else
                foreach (ChatText str in listBoxChat.Items)
                    chat_screen.textChat.Text += str.text + "\n";
        }

        //Select on right mouse click
        private void listBoxChat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                listBoxChat.SelectedIndex = listBoxChat.IndexFromPoint(e.X, e.Y);
            }
        }

        //Moderator chat
        private void modChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                WriteText("Moderator: " + modChat.Text, "Offscreen");
                modChat.Text = string.Empty;
            }
        }
        #endregion
    }
}

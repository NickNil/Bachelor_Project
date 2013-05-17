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
        int maxLines;

        public Chat_offscreen()
        {
            InitializeComponent();
        }

        public Chat_offscreen(Chat_screen chat_screen)
        {
            InitializeComponent();
            this.chat_screen = chat_screen;
            this.listBoxChat.ItemAdded += new EventHandler<ListBoxItemEventArgs>(listBoxChat_ItemAdded);
            this.chat_screen.Resize += new System.EventHandler(this.Chat_screen_Resize);

            listBoxChat.ContextMenuStrip = contextMenuStrip;
            contextMenuStrip.Items.Add("Slett");
            contextMenuStrip.Items.Add("Utesteng IP");
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
            while (listBoxChat.Items.Count >= MAX)
                listBoxChat.Items.RemoveAt(0);
            listBoxChat.AddItem(new ChatText(text, ip));

            UpdateText();
        }

        public void UpdateText()
        {
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
        #endregion

        #region Private Methods

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (listBoxChat.SelectedItem == null)
                return;

            ChatText temp = (ChatText)listBoxChat.SelectedItem;
            if (e.ClickedItem.Text == "Slett")
            {
                listBoxChat.Items.RemoveAt(listBoxChat.SelectedIndex);
                UpdateText();
            }
            else if (e.ClickedItem.Text == "Utesteng IP")
            {
                if (!Base_offscreen.CheckBlacklist(temp.ip))
                    Base_offscreen.blackList.Add(temp.ip);

                for (int i = 0; i < listBoxChat.Items.Count; i++)
                {
                    if (((ChatText)listBoxChat.Items[i]).ip == temp.ip)
                        listBoxChat.Items.RemoveAt(i);
                }
                UpdateText();
            }
        }

        private void Chat_screen_Resize(object sender, EventArgs e)
        {
            //Get height of font
            maxLines = (chat_screen.Height / TextRenderer.MeasureText("blah", chat_screen.textChat.Font).Height);

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
                WriteText("Moderator: " + modChat.Text, "Mod");
                modChat.Text = string.Empty;
            }
        }

        private void listBoxChat_ItemAdded(object sender, EventArgs e)
        {
            //Autoscroll offscreen
            listBoxChat.TopIndex = listBoxChat.Items.Count - 1;
        }
        #endregion
    }
}

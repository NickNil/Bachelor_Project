﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Solution
{
    public partial class Chat_offscreen : Form
    {
        Chat_screen chat_screen;

        public Chat_offscreen()
        {
            InitializeComponent();
        }

        public Chat_offscreen(Chat_screen frm)
        {
            InitializeComponent();
            chat_screen = frm;
        }

        private void textToChat_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                chat_screen.textChat.Text += textToChat.Text;
                textToChat.Clear();
            }
        }
    }
}
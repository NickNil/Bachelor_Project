using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Solution
{
    public class Chat
    {
        public Chat_screen chat_screen;
        public Chat_offscreen chat_offscreen;

        public Chat()
        {
            InitializeComponent();
        }
        public Chat(Base_offscreen frm)
        {
            InitializeComponent();
            chat_screen = new Chat_screen();
            chat_offscreen = new Chat_offscreen(chat_screen);
            
        }

        private void InitializeComponent()
        {
            
        }
    }
}

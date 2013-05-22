using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseApplication
{
    public class Chat
    {
        public Chat_screen chat_screen;
        public Chat_offscreen chat_offscreen;

        public Chat()
        {
            chat_screen = new Chat_screen();
            chat_offscreen = new Chat_offscreen(chat_screen);     
        }
    }
}

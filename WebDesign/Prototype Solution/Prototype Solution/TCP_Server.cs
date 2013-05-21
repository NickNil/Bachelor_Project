using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Diagnostics;

namespace Prototype_Solution
{
    class TCP_Server
    {
        //Moduler
        Chat chat;
        Jukebox jukebox;

        int test = 0;

        string playlist;

        static TcpListener listener;
        const int LIMIT = 50; //50 concurrent clients

        public TCP_Server(Chat chat, Jukebox jukebox)
        {
            //Moduler
            this.chat = chat;
            this.jukebox = jukebox;

            listener = new TcpListener(IPAddress.Loopback, 2055);
            listener.Start();

            Console.WriteLine("Server mounted, listening to port 2055");

            for (int i = 0; i < LIMIT; i++)
            {
                Thread t = new Thread(new ThreadStart(Service));
                t.Start();
            }
        }

        public void Service()
        {
            while (true)
            {
                Socket soc = listener.AcceptSocket();

                test++;
                Console.WriteLine("Connected: {0}", soc.RemoteEndPoint);
                Console.WriteLine(test);


                string ip = string.Empty;

                try
                {
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true; // enable automatic flushing

                    string content = sr.ReadLine();
                    
                    if (content.IndexOf("IP=") == 0)
                        content = CheckIP(content, ref ip);

                    //Moduler
                    if (content.IndexOf("Chat=") == 0)
                        TryChat(content.Remove(0, 5), ip);

                    if (content.IndexOf("Jukebox=") == 0)
                        TryJukebox(sw, content.Remove(0, 8));

                    s.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "\n nothing");
                }

                test--;
                Console.WriteLine("Disconnected: {0}", soc.RemoteEndPoint);
                Console.WriteLine(test);

                soc.Close();
            }
        }

        public void Send_msg(StreamWriter sw, string message)
        {
            try
            {
                sw.WriteLine(message);
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString() + "\n failed to send message for some reason"); }

        }

        public string CheckIP(string content, ref string ip)
        {
            content = content.Remove(0, content.IndexOf("[") + 1);
            ip = content.Remove(content.IndexOf("]"));
            if (Base_offscreen.CheckBlacklist(ip))
                return "";
            else
                return content.Remove(0, content.IndexOf("]") + 1);
        }

        //Moduler

        public void TryChat(string content, string ip)
        {
            if (chat != null)
                chat.chat_offscreen.SetText(content, ip);
        }

        public void TryJukebox(StreamWriter sw, string content)
        {
            if (jukebox != null)
            {
                if (content.Contains("Page Load"))
                {
                    foreach (string song in jukebox.jb_offscreen.songs2)
                        playlist += song + ";;";
                    Send_msg(sw, playlist);
                }
                else
                {
                    jukebox.jb_offscreen.Vote(content);
                }

            }
        }
    }
}

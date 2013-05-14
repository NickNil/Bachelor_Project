﻿using System;
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
        Chat chat;
        Jukebox jukebox;

        string playlist;

        static TcpListener listener;
        const int LIMIT = 5; //5 concurrent clients

        public TCP_Server(Chat chat, Jukebox jukebox)
        {
            this.chat = chat;
            this.jukebox = jukebox;

            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];
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

                Console.WriteLine("Connected: {0}", soc.RemoteEndPoint);

                //Check blacklist
                string ip = ((IPEndPoint)(soc.RemoteEndPoint)).Address.ToString();
                if (Base_offscreen.CheckBlacklist(ip))
                    return;

                try
                {
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true; // enable automatic flushing

                    string content = sr.ReadLine();

                    if (content.IndexOf("IP=") == 0)
                        content = CheckIP(content, ref ip);

                    if (content.IndexOf("Chat=") == 0)
                        TryChat(content.Remove(0, 5), ip);

                    if (content.IndexOf("Jukebox=") == 0)
                        TryJukebox(sw, content.Remove(0, 8));

                    s.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Disconnected: {0}", soc.RemoteEndPoint);

                soc.Close();
            }
        }

        public void Send_msg(StreamWriter sw, string message)
        {
            try
            {
                sw.WriteLine(message);
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); }

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
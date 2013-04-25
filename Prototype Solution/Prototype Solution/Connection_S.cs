using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
//http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(EHInvalidOperation.WinForms.IllegalCrossThreadCall);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.0);k(DevLang-csharp)&rd=true
//http://www.codeproject.com/Articles/463947/Working-with-Sockets-in-Csharp

namespace Prototype_Solution
{ 
    class Connection_S
    {
        Chat chat;
        Jukebox jukebox;

        string playlist;

        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;

        public Connection_S(Chat chat, Jukebox jukebox)
        {
            try
            {
                this.chat = chat;
                this.jukebox = jukebox;
                

                permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);

                sListener = null;
                permission.Demand();

                IPHostEntry ipHost = Dns.GetHostEntry("");
                IPAddress ipAddr = ipHost.AddressList[0];

                ipEndPoint = new IPEndPoint(ipAddr, 3447);

                sListener = new Socket(
                    ipAddr.AddressFamily,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );

                

                sListener.Bind(ipEndPoint);

                sListener.Listen(100);

                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                sListener.BeginAccept(aCallback, sListener);
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); } 
        }

        #region Public Methods

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket listener = null;
                Socket handler = null;

                byte[] buffer = new byte[1024];

                listener = (Socket)ar.AsyncState;
                handler = listener.EndAccept(ar);

                //Check blacklist
                string ip = ((IPEndPoint)(handler.RemoteEndPoint)).Address.ToString();
                if (Base_offscreen.CheckBlacklist(ip))
                    return;

                handler.NoDelay = false;

                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;

                handler.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), obj);

                AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                listener.BeginAccept(aCallback, listener);
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); }

        }


        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                byte[] buffer = (byte[])obj[0];

                handler = (Socket)obj[1];

                string content = string.Empty;
                string ip = string.Empty;

                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.Unicode.GetString(buffer, 0,
                        bytesRead);

                    if (content.IndexOf("IP=") == 0)
                        content = CheckIP(content, ref ip);

                    if (content.IndexOf("Chat=") == 0)
                        TryChat(content.Remove(0, 5), ip);

                    else if (content.IndexOf("Jukebox=") == 0)
                        TryJukebox(content.Remove(0, 8));
                    else
                        return;


                    byte[] buffernew = new byte[1024];
                    obj[0] = buffernew;
                    obj[1] = handler;
                    handler.BeginReceive(buffernew, 0, buffernew.Length,
                        SocketFlags.None,
                        new AsyncCallback(ReceiveCallback), obj);

                }
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); }

        }

        public void Send_msg(string message)
        {
            try
            {
                if (message != null)
                {
                    // Prepare the reply message  
                    byte[] byteData =
                        Encoding.Unicode.GetBytes(message);

                    // Sends data asynchronously to a connected Socket  
                    handler.BeginSend(byteData, 0, byteData.Length, 0,
                        new AsyncCallback(SendCallback), handler);
                }
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); }

        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // A Socket which has sent the data to remote host  
                Socket handler = (Socket)ar.AsyncState;

                // The number of bytes sent to the Socket  
                int bytesSend = handler.EndSend(ar);
                Console.WriteLine(
                    "Sent {0} bytes to Client", bytesSend);
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

        public void TryJukebox(string content)
        {
            try
            {
                if (jukebox != null)
                {
                    if (content.Contains("Page Load"))
                    {
                        playlist = string.Empty;
                        foreach (string song in jukebox.jb_offscreen.songs2)
                            playlist += song + "\n";

                        if (playlist != null)
                            Send_msg(playlist);
                        else
                            return; //Gi error!!
                    }
                    else
                    {
                        jukebox.jb_offscreen.Vote(content);
                    }

                }
            }
            catch (Exception exc) { Debug.WriteLine("Error \n\n " + exc.ToString()); }
        } 
        #endregion
    }
}

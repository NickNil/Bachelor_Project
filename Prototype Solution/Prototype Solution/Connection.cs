using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
//http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(EHInvalidOperation.WinForms.IllegalCrossThreadCall);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.0);k(DevLang-csharp)&rd=true
//http://www.codeproject.com/Articles/463947/Working-with-Sockets-in-Csharp

namespace Prototype_Solution
{ 
    class Connection
    {
        Chat_screen chat_screen;

        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;

        public Connection(Chat_screen c)
        {
            chat_screen = c;

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

            sListener.Listen(10);

            AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
            sListener.BeginAccept(aCallback, sListener); 
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;
            Socket handler = null;

            byte[] buffer = new byte[1024];
 
            listener = (Socket)ar.AsyncState;
            handler = listener.EndAccept(ar);

            object[] obj = new object[2];
            obj[0] = buffer;
            obj[1] = handler;

            handler.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), obj); 

            AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
            listener.BeginAccept(aCallback, listener);
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            object[] obj = new object[2];
            obj = (object[])ar.AsyncState;

            byte[] buffer = (byte[])obj[0];

            handler = (Socket)obj[1];

            string content = string.Empty;
 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                content += Encoding.Unicode.GetString(buffer, 0,
                    bytesRead);

                chat_screen.SetText(content);

                if (content.IndexOf("<Client Quit>") > -1)
                {
                    string str = content.Substring(0, content.LastIndexOf("<Client Quit>"));
                }
                else
                {
                    byte[] buffernew = new byte[1024];
                    obj[0] = buffernew;
                    obj[1] = handler;
                    handler.BeginReceive(buffernew, 0, buffernew.Length,
                        SocketFlags.None,
                        new AsyncCallback(ReceiveCallback), obj);
                }
            }

        }
    }
}

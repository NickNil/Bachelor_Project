using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Sockets;
//http://www.codeproject.com/Articles/463947/Working-with-Sockets-in-Csharp

namespace HPWeb1
{
    public class Connection
    {
        
        byte[] bytes = new byte[1024];
        Socket senderSock;

        public Connection()
        {
            SocketPermission permission = new SocketPermission(
                   NetworkAccess.Connect,    // Connection permission  
                   TransportType.Tcp,        // Defines transport types  
                   "",                       // Gets the IP addresses  
                   SocketPermission.AllPorts // All ports  
                   );

            // Ensures the code to have permission to access a Socket  
            permission.Demand();

            // Resolves a host name to an IPHostEntry instance             
            IPHostEntry ipHost = Dns.GetHostEntry("");

            // Gets first IP address associated with a localhost  
            IPAddress ipAddr = ipHost.AddressList[0];

            // Creates a network endpoint  
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 3447);

            // Create one Socket object to setup Tcp connection  
            senderSock = new Socket(
                ipAddr.AddressFamily,// Specifies the addressing scheme  
                SocketType.Stream,   // The type of socket   
                ProtocolType.Tcp     // Specifies the protocols   
                );

            //senderSock.NoDelay = false;   // Using the Nagle algorithm  

            // Establishes a connection to a remote host  
            senderSock.Connect(ipEndPoint); 
        }

        public void Send(string s)
        {
            byte[] msg = Encoding.Unicode.GetBytes(s);

            // Sends data to a connected Socket.  
            int bytesSend = senderSock.Send(msg); 
        }
    }
}
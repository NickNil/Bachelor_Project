using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Net;
using System.Net.Sockets;

using System.Diagnostics;

namespace WebDesign
{
    public class TCP_Client
    {
        TcpClient client = new TcpClient();

        Stream s;
        StreamReader sr;
        StreamWriter sw;
        

        public TCP_Client()
        {
            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];

            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, 2055);
            client.Connect(ipEndPoint);
            
            try
            {
                
                s = client.GetStream();
                sr = new StreamReader(s);
                sw = new StreamWriter(s);
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); } 

        }

        public void Send(string message)
        {
            try
            {
                sw.AutoFlush = true;
                // Sends data to a connected Socket.  
                sw.WriteLine(message);

            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); } 
        }

        public string ReceiveDataFromServer()
        {
            try
            {
                // Receives data from a bound Socket.  
                String receivedData = sr.ReadLine();
                return receivedData;
            }
            catch (Exception exc) { Debug.WriteLine(exc.ToString()); }
            return "failed to get playlist";
        } 

    }
}
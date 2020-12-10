using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace UDP_Receiver_Broadcast
{
    public class UDPReceiver
    {
        public async System.Threading.Tasks.Task StartAsync()
        {
            UdpClient UdpReceiver = new UdpClient(7000);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Receiver is blocked");

            
            try
            {

               
                while (true)
                {
                    
                        Byte[] bytesreceived = UdpReceiver.Receive(ref endPoint);
                        string receivedData = Encoding.ASCII.GetString(bytesreceived);

                        Console.WriteLine("Sender is " + receivedData.ToString());
                        Console.WriteLine("This Message was sent from" + " " + endPoint.Address.ToString());
                        Console.WriteLine("On Port" + " " + endPoint.Port.ToString());

                        MSG.PostAsync(new MSG(receivedData));   

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

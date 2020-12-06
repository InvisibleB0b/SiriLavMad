using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace UDP_Receiver_Broadcast
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
           


            UDPReceiver udpReceiver = new UDPReceiver();
            udpReceiver.StartAsync();
        }
    }
}

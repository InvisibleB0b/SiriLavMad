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
        private static readonly string baseUrl = "https://websiterecipeexam.azurewebsites.net/";
        public async System.Threading.Tasks.Task StartAsync()
        {
            UdpClient UdpReceiver = new UdpClient(9999);
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

                    HttpClientHandler handler = new HttpClientHandler();

                    handler.UseDefaultCredentials = true;

                    using (var client = new HttpClient(handler))
                    {

                        client.BaseAddress = new Uri(baseUrl);

                        client.DefaultRequestHeaders.Clear();

                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                        client.DefaultRequestHeaders.Connection.Add("keep-alive");

                        try
                        {
                            var response = client.PostAsJsonAsync($"recipe/vegan/{receivedData.ToString()}", "").Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("Yes");
                            }
                            else
                            {
                                Console.WriteLine("fail");
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                    }

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

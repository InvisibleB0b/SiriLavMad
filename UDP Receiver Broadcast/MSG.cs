using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace UDP_Receiver_Broadcast
{
    public class MSG
    {
        

        public string msg { get; set; }

        public MSG()
        {
            
        }

        public MSG(string msg)
        {
            this.msg = msg;
        }


        public static async void PostAsync(MSG value)
        {
            using (HttpClient client = new HttpClient())
            {
                string postBody = JsonConvert.SerializeObject(value);
                StringContent stringContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:55980/IOT/Post", stringContent);
                Console.WriteLine("Posting Object to Api");
            }
        }

        public override string ToString()
        {
            return $"{nameof(msg)}: {msg}";
        }
    }
}

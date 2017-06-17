using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Proyecto_Final___Xamarin_Ver.Requests
{
    class PushRequest
    {
        public void sendPush(string user_id, string title, string message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("userId", user_id),
                    new KeyValuePair<string, string>("title", title),
                    new KeyValuePair<string, string>("message", message)
                });
                    HttpResponseMessage result = client.PostAsync(Utils.Constants.sendPush, content).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

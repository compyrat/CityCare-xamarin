using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Proyecto_Final___Xamarin_Ver.Requests
{
    class IncidenceRequest
    {
        public List<JSON.Incidence> getAllIncidencesData()
        {
            try
            {
                List<JSON.Incidence> array = new List<JSON.Incidence>();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getAllIncidencesData).Result;
                    JToken token = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    string error = (string)token.SelectToken("error");
                    JArray jarray = (JArray)token.SelectToken("incidencias");
                    array = jarray.ToObject<List<JSON.Incidence>>();
                    return array;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public JSON.Incidence getIncidence(string id)
        {
            JSON.Incidence incidence = new JSON.Incidence();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getIncidence + id).Result;
                    JToken token = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    JObject jobject = (JObject)token.SelectToken("incidencia");
                    incidence = jobject.ToObject<JSON.Incidence>();
                    return incidence;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void setRead(string id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.checkRead + id).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void changeStatus(string id, int status)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.setStatus + id + "/" + status).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void deleteIncidence(string inc_id, string img_name)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    FormUrlEncodedContent content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("userId", "Admin"),
                    new KeyValuePair<string, string>("incidenceId", inc_id),
                    new KeyValuePair<string, string>("imageName", img_name)
                });
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.PostAsync(Utils.Constants.deleteIncidence, content).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public int[] getAllCount()
        {
            int[] count = new int[6];
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getCountAll).Result;
                    JToken token = JToken.Parse(result.Content.ReadAsStringAsync().Result);
                    JArray array = (JArray)token.SelectToken("count");
                    foreach (JObject ob in array)
                    {
                        count[(int)ob.SelectToken("_id")] = (int)ob.SelectToken("count");
                    }
                    return count;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int[] getAllCountCategory()
        {
            int[] count = new int[6];
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getAllCategory).Result;
                    JToken token = JToken.Parse(result.Content.ReadAsStringAsync().Result);
                    JArray array = (JArray)token.SelectToken("count");
                    foreach (JObject ob in array)
                    {
                        count[(int)ob.SelectToken("_id")] = (int)ob.SelectToken("count");
                    }
                    return count;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string getCount(string id)
        {
            string count;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getCount + id).Result;
                    count = result.Content.ReadAsStringAsync().Result;
                }
                return count;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string getCountSolved(string id)
        {
            string count;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getCountSolved + id).Result;
                    count = result.Content.ReadAsStringAsync().Result;
                }
                return count;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
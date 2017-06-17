using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;


namespace Proyecto_Final___Xamarin_Ver.Requests
{
    class UserRequests
    {
        public int[] getAllUsersType()
        {
            int[] count = new int[4];
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getAllUsersType).Result;
                    JToken token = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    count[0] = (int)token.SelectToken("noBan");
                    count[1] = (int)token.SelectToken("ban");
                    count[2] = (int)token.SelectToken("face");
                    count[3] = (int)token.SelectToken("noFace");
                }
                return count;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public string registerUser(string name, string email, string lastname, string password)
        {
            string requestResult = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name",name),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("lastname", lastname),
                new KeyValuePair<string, string>("password", Utils.SecurityUtilities.Sha1Digest(password)),
                new KeyValuePair<string, string>("accountType", "admin")
            });
                    HttpResponseMessage result = client.PostAsync(Utils.Constants.registerUserURL, content).Result;
                    JToken jsonToken = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    int error = (int)jsonToken.SelectToken("error");
                    if (error == 0)
                    {
                        requestResult = "Usuario registrado";
                    }
                    else if (error == 1)
                    {
                        requestResult = "Correo electrónico ya en uso";
                    }
                    else if (error == 2)
                    {
                        requestResult = "Error en el servidor";
                    }
                }
                return requestResult;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public void editUser(string id, string name, string email, string lastname, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    if (password.Equals(""))
                    {
                        password = null;
                    }
                    FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", id),
                new KeyValuePair<string, string>("name",name),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("lastname", lastname),
                new KeyValuePair<string, string>("password", password),
            });
                    HttpResponseMessage result = client.PostAsync(Utils.Constants.editUserData, content).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public string deleteUser(string id)
        {
            string requestResult = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.deleteUserData + id).Result;
                    requestResult = result.Content.ReadAsStringAsync().Result;
                }
                return requestResult;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void blockUser(string id, string status)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    FormUrlEncodedContent content = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("status", status),
                });
                    HttpResponseMessage result = client.PostAsync(Utils.Constants.blockUser, content).Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public JSON.User getUserData(string _id)
        {
            JSON.User user = new JSON.User();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getUserData + _id).Result;
                    JToken token = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    string error = (string)token.SelectToken("error");
                    JObject jObject = (JObject)token.SelectToken("user");
                    user = jObject.ToObject<JSON.User>();
                    user.numberIncidences = token.SelectToken("numberIncidences").ToString();
                    user.numberIncidencesSolved = token.SelectToken("numberIncidencesSolved").ToString();
                    return user;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<JSON.User> getAllUsersData()
        {
            List<JSON.User> array = new List<JSON.User>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Utils.Constants.serverAddress);
                    HttpResponseMessage result = client.GetAsync(Utils.Constants.getAllUsersData).Result;
                    /*JToken jsonToken = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    user.name = (string)jsonToken.SelectToken("name");
                    user.email = (string)jsonToken.SelectToken("email");
                    user.lastname = (string)jsonToken.SelectToken("lastname");
                    user.password = (string)jsonToken.SelectToken("password");
                    user.id = (string)jsonToken.SelectToken("_id");*/
                    // var des = Newtonsoft.Json.JsonConvert.DeserializeObject<JSON.UserList>(f);
                    JToken token = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    string error = (string)token.SelectToken("error");
                    if (error.Equals("1"))
                    {
                        return null;
                    }
                    JArray a = (JArray)token.SelectToken("item");
                    array = a.ToObject<List<JSON.User>>();
                    /* JSON.User user = new JSON.User();
                     foreach (JObject o in a.Children<JObject>())
                     {
                          foreach (JProperty p in o.Properties())
                          {
                             string name = p.Name;
                             string value = (string)p.Value;
                             if (name.Equals("nombre"))
                             {
                                 user.nombre = value;
                             }
                             }
                          array.Add(user);
                     }*/
                    return array;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SummerCamp.CyberHelp.Mobile
{
    public class DataService
    {
        private const string URL = "http://cyberhelpweb.azurewebsites.net/api";

        public async Task<Model.Room[]> GetRooms()
        {
            //using (var client = new HttpClient())
            //{
            //    string url = $"{URL}/classroom";
            //    var json = await client.GetStringAsync(url);

            //    var result = JsonConvert.DeserializeObject<IList<Model.WebApi.ClassRoom>>(json);

            //    return result.Select(i => new Model.Room()
            //    {
            //        ID = i.classRoomID,
            //        Name = i.classRoomName
            //    })
            //    .ToArray();
            //}

            List<Model.Room> _rooms = new List<Model.Room>();
            _rooms.Add(new Model.Room() { ID = 2, Name = "Académie Provinciale des métiers" });
            _rooms.Add(new Model.Room() { ID = 3, Name = "Athénée Royale Marguerite Bervoets" });
            _rooms.Add(new Model.Room() { ID = 4, Name = "Athénée Provincial Jean d’Avesnes" });
            _rooms.Add(new Model.Room() { ID = 5, Name = "Athénée Royal Mons 1" });
            _rooms.Add(new Model.Room() { ID = 6, Name = "Ecole du futur ICES Quaregnon" });
            _rooms.Add(new Model.Room() { ID = 7, Name = "Ecoles des religieuses Ursulines" });
            _rooms.Add(new Model.Room() { ID = 8, Name = "Sacré Coeur de Mons" });
            _rooms.Add(new Model.Room() { ID = 9, Name = "Institut Saint Ferdinand" });
            _rooms.Add(new Model.Room() { ID = 10, Name = "Instituts Saint-Luc" });
            _rooms.Add(new Model.Room() { ID = 11, Name = "Collège Saint Stanislas" });
            return _rooms.ToArray();
        }

        public bool RegisterUser(Model.User user)
        {
            return true;
        }

        public async Task<bool> SendNewAlertAsync(Model.WebApi.Alert newAlert)
        {
            string url = $"{URL}/alert";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(newAlert);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;

        }

        public async Task<Model.WebApi.Alert[]> GetAlerts(int userID)
        {
            try
            {
                var uri = new Uri($"{URL}/alert");

                WebRequest request = WebRequest.Create(uri.ToString());
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();

                reader.Close();
                response.Close();

                var result = JsonConvert.DeserializeObject<IList<Model.WebApi.Alert>>(json);

                return result.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

    }
}



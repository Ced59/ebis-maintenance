using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;

namespace WPF.MonAppli.CoucheDonnees.Models
{
    public class GetAllBornes
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetAllBornes()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/bornes", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<Borne> LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<Borne>>(response.Content);
        }
    }
}
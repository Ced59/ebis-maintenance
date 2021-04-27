using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.UsagerEntities;

namespace WPF.MonAppli.CoucheDonnees.Models
{
    public class GetAllUsagers
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetAllUsagers()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/usagers", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<Usager> LaunchRequestAsync()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<Usager>>(response.Content);
        }
    }
}
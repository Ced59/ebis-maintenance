using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.EntretienEntities;

namespace WPF.MonAppli.CoucheDonnees.Models
{
    public class GetAllEntretiens
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetAllEntretiens()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/entretiens", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<Entretien> LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<Entretien>>(response.Content);
        }
    }
}

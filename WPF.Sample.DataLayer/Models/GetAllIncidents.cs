using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentEntitie;

namespace WPF.MonAppli.CoucheDonnees.Models
{
    public class GetAllIncidents
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetAllIncidents()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<Incident> LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<Incident>>(response.Content);
        }
    }
}

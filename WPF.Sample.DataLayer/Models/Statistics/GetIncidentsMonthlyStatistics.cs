using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentsMonthlyAverageEntities;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    public class GetIncidentsMonthlyStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetIncidentsMonthlyStatistics(int deltaYear)
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents/get-average", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public IncidentsMonthlyAverage LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<IncidentsMonthlyAverage>(response.Content);
        }
    }
}
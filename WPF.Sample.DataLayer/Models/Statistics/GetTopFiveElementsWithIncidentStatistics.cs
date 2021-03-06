using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    public class GetTopFiveElementsWithIncidentStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetTopFiveElementsWithIncidentStatistics()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents/top-five-defective-elements", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<StatElementDefectueux> LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<StatElementDefectueux>>(response.Content);
        }
    }
}
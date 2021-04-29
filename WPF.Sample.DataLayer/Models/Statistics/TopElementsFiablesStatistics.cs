using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    public class TopElementsFiablesStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public TopElementsFiablesStatistics()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents/top-five-reliable-elements", Method.GET)
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

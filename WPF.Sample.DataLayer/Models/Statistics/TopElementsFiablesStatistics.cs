using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    class TopElementsFiablesStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public TopElementsFiablesStatistics(int deltaYear)
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents/top-five-reliable-elements", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public ElementsFiableAverage LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<ElementFiableAverage>(response.Content);
        }
    }
}

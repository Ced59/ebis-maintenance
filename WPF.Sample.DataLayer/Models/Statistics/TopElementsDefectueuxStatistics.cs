using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    class TopElementsDefectueuxStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public TopElementsDefectueuxStatistics(int deltaYear)
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/incidents/top-five-defective-elements", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public ElementsDefectueuxAverage LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<ElementDefectueuxAverage>(response.Content);
        }
    }
}

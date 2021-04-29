using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.AverageElementFunctionnementEntities;

namespace WPF.MonAppli.CoucheDonnees.Models.Statistics
{
    public class AverageElementFunctionnementsStatistics
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public AverageElementFunctionnementsStatistics()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/bornes/average-elements-functionnement", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public AverageElementFunctionnement LaunchRequest()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<AverageElementFunctionnement>(response.Content);
        }
    }
}

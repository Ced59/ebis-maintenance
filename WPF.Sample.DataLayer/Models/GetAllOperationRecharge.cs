using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MonAppli.CoucheDonnees.Entities.OperationRechargeEntities;

namespace WPF.MonAppli.CoucheDonnees.Models
{
    public class GetAllOperationRecharge
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public GetAllOperationRecharge()
        {
            Client = new RestClient("https://localhost:44360");
            Request = new RestRequest("api/operations-recharge", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            Request.AddHeader("Content-Type", "application/json");
        }

        public List<OperationRecharge> LaunchRequestAsync()
        {
            var response = Client.ExecuteAsync(Request).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<List<OperationRecharge>>(response.Content);
        }
    }
}

using Newtonsoft.Json;
using System;

namespace API.EbisMaintenance.Entities.CrudOperations
{
    public class ModelBase
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public string Document { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations
{
    public class ModelBase
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        public string Document { get; set; }
    }
}

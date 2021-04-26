using Newtonsoft.Json;
using System;

namespace API.EbisMaintenance.Dto.CrudOperations
{
    public class ModelBaseDTO
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "document")]
        public string Document { get; set; }
    }
}

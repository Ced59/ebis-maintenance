using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Usager
{
    class ModeleBatterieDTO
    {
        [JsonProperty(PropertyName = "fabricant")]
        public string Fabricant { get; set; }
        [JsonProperty(PropertyName = "capacite")]
        public float Capacite { get; set; }
    }
}

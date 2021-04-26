using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Incident
{
    class ElementVérifiéDTO
    {
        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}

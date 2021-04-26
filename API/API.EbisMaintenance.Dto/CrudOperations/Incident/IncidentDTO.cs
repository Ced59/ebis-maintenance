using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Incident
{
    class IncidentDTO
    {
        [JsonProperty(PropertyName = "operationRecharge")]
        public Guid OperationRecharge { get; set; }

        [JsonProperty(PropertyName = "numeroBorne")]
        public Guid NumeroBorne { get; set; }

        [JsonProperty(PropertyName = "technicien")]
        public Guid Technicien { get; set; }

        [JsonProperty(PropertyName = "resolu")]
        public bool Resolu { get; set; }

        [JsonProperty(PropertyName = "elementVérifié")]
        public List<ElementVérifiéDTO> ElementVérifié { get; set; }
    }
}

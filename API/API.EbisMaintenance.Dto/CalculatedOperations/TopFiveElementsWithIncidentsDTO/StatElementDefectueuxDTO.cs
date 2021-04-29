using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO
{
    public class StatElementDefectueuxDTO
    {
        [JsonProperty(PropertyName = "element")]
        public string Element { get; set; }

        [JsonProperty(PropertyName = "nbreIncidents")]
        public int NbreIncidents { get; set; }
    }
}
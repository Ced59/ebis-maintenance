using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO
{
    public class TopFiveElementsWithIncidentDTO
    {
        [JsonProperty(PropertyName = "statsElements")]
        public List<StatElementDefectueuxDTO> StatsElements { get; set; }
    }
}
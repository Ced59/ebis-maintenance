using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.IncidentsMonthlyAveragesDTO
{
    public class IncidentsMonthlyAverageDTO
    {
        [JsonProperty(PropertyName = "averageGeneral")]
        public float Average { get; set; }

        [JsonProperty(PropertyName = "detailsMonthly")]
        public List<MonthlyIncidentCountDTO> MonthlyIncidentCount { get; set; }
    }
}
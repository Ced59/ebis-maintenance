using API.EbisMaintenance.Dto.CrudOperations.IncidentsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.EbisMaintenance.Dto.CalculatedOperations.IncidentsMonthlyAveragesDTO
{
    public class MonthlyIncidentCountDTO
    {
        [JsonProperty(PropertyName = "month")]
        public DateTime Month { get; set; }

        [JsonProperty(PropertyName = "nbreIncidentsMonthly")]
        public float NbreIncidentMonthly { get; set; }
    }
}
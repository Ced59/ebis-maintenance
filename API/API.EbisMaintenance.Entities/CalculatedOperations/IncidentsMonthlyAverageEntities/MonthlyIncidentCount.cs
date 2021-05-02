using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CalculatedOperations.IncidentsMonthlyAverageEntities
{
    public class MonthlyIncidentCount
    {
        public DateTime Month { get; set; }

        public float NbreIncidentMonthly { get; set; }
    }
}
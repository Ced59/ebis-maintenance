using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.MonAppli.CoucheDonnees.Entities.IncidentsMonthlyAverageEntities
{
    public class IncidentsMonthlyAverage
    {
        public float Average { get; set; }
        public List<MonthlyIncidentCount> MonthlyIncidentCount { get; set; }
    }
}
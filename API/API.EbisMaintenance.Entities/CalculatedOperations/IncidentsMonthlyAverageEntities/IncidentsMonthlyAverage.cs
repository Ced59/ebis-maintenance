using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.EbisMaintenance.Entities.CalculatedOperations.IncidentsMonthlyAverageEntities
{
    public class IncidentsMonthlyAverage
    {
        private List<Incident> _allIncidents;
        private List<Incident> _incidentsDeltaYear;

        public float Average { get; set; }
        public List<MonthlyIncidentCount> MonthlyIncidentCount { get; set; }

        public IncidentsMonthlyAverage(List<Incident> allIncidents)
        {
            _allIncidents = allIncidents;
        }

        public IncidentsMonthlyAverage GetStats(int deltaYear)
        {
            var limitDate = DateTime.Now.AddYears(-deltaYear);

            _incidentsDeltaYear = _allIncidents.Where(i => i.OperationRecharge.DateHeureFin >= limitDate).ToList();

            Average = (float)Math.Round((double)_incidentsDeltaYear.Count / ((double)deltaYear * 12), 2);

            MonthlyIncidentCount = GetStatsByMonth(_incidentsDeltaYear, deltaYear);

            return this;
        }

        private List<MonthlyIncidentCount> GetStatsByMonth(List<Incident> incidentsDeltaYear, int deltaYear)
        {
            var listMonthlyCount = new List<MonthlyIncidentCount>();

            var stepMonth = deltaYear * 12;

            List<DateTime> listMonths = new List<DateTime>();

            for (var i = 0; i <= stepMonth; i++)
            {
                listMonths.Add(DateTime.Now.AddMonths(-i));
            }

            for (var i = 0; i < listMonths.Count; i++)
            {
                var beginMonth = new DateTime(listMonths[i].Year, listMonths[i].Month, 1);

                listMonthlyCount.Add(new MonthlyIncidentCount
                {
                    Month = beginMonth,
                    NbreIncidentMonthly = GetNbreIncidentMonth(beginMonth, incidentsDeltaYear)
                });
            }

            return listMonthlyCount;
        }

        private float GetNbreIncidentMonth(DateTime beginMonth, List<Incident> incidentsDeltaYear)
        {
            var finMonth = new DateTime(beginMonth.Year, beginMonth.Month, DateTime.DaysInMonth(beginMonth.Year, beginMonth.Month));

            var nbreIncident = incidentsDeltaYear
                .Where(i => i.OperationRecharge.DateHeureFin >= beginMonth && i.OperationRecharge.DateHeureFin <= finMonth)
                .ToList()
                .Count;

            return nbreIncident;
        }
    }
}
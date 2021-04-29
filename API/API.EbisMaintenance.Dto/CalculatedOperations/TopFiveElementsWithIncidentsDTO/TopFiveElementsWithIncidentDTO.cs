using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO
{
    public class TopFiveElementsWithIncidentDTO
    {
        public List<StatElementDefectueuxDTO> StatsElements { get; set; }
    }
}
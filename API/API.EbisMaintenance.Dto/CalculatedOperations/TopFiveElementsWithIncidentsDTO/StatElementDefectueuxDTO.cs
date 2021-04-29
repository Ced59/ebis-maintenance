using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.TopFiveElementsWithIncidentsDTO
{
    public class StatElementDefectueuxDTO
    {
        public string Element { get; set; }
        public int NbreIncidents { get; set; }
    }
}
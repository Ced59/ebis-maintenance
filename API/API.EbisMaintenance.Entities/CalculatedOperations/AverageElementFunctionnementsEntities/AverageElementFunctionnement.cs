using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CalculatedOperations.AverageElementFunctionnementsEntities
{
     public class AverageElementFunctionnement
    {
        public int NbreBorne { get; set; }

        public List<ChangementElements> ChangementElements { get; set; }
    }
}

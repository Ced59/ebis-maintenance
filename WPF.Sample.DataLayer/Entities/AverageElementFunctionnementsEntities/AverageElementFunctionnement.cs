using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.MonAppli.CoucheDonnees.Entities.AverageElementFunctionnementEntities
{
     public class AverageElementFunctionnement
    {
        public int NbreBorne { get; set; }

        public List<ChangementElements> ChangementElements { get; set; }
    }
}

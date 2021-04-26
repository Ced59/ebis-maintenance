using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Borne
{
    public class Borne : ModelBase
    {
        public DateTime DateMiseEnService { get; set; }

        public DateTime DateDerniereRevision { get; set; }

        public Station Station { get; set; }

        public List<TypeCharge> TypeCharge { get; set; }
    }
}

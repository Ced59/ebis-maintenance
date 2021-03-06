using System;
using System.Collections.Generic;

namespace WPF.MonAppli.CoucheDonnees.Entities.BorneEntities
{
    public class Borne : ModelBase
    {
        public DateTime DateMiseEnService { get; set; }

        public DateTime DateDerniereRevision { get; set; }

        public Station Station { get; set; }

        public List<TypeCharge> TypeCharge { get; set; }
    }
}
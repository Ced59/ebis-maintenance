using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using System;
using System.Collections.Generic;
using System.Text;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;
using WPF.MonAppli.CoucheDonnees.Entities.EntretienEntities;

namespace WPF.MonAppli.CoucheDonnees.Entities.EntretienEntities
{
    public class Entretien : ModelBase
    {
        public List<ElementsVerifies> ElementsVerifies { get; set; }

        public bool Resolu { get; set; }

        public Incident Incident { get; set; }

        public Borne Borne { get; set; }
    }
}
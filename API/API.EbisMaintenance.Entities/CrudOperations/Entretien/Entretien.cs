using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.EntretienEntitie
{
    public class Entretien : ModelBase
    {
        public List<ElementsVerifies> ElementsVerifies { get; set; }

        public bool Resolu { get; set; }

        public Incident Incident { get; set; }

        public Borne Borne { get; set; }

        public DateTime DateIntervention { get; set; }
    }
}
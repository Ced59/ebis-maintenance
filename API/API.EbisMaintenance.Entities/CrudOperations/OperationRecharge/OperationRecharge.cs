using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.OperationRecharge
{
    class OperationRecharge
    {

        public DateTime DateHeureDebut { get; set; }

        public DateTime DateHeureFin { get; set; }

        public float NbKwHeures { get; set; }

        public Guid Borne { get; set; }

        public string NoContrat { get; set; }

        public string Prenom { get; set; }

        public List<Controle> Controle { get; set; } 

        public bool demandeEntretien { get; set; }
 

    }
}

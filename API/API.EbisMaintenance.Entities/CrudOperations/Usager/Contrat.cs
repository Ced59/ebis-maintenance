using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie
{
    public class Contrat
    {
        public DateTime DateContrat { get; set; }

        public string NoImmatriculation { get; set; }

        public Abonnement Abonnement { get; set; }

        public ForfaitPrepaye ForfaitPrepaye { get; set; }

        public ModeleBatterie ModeleBatterie { get; set; } 

    }
}

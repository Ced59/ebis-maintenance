using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Usager
{
    class Contrat
    {
        public DateTime DateContrat { get; set; }

        public string NoImmatriculation { get; set; }

        public Abonnement Abonnement { get; set; }

        public ForfaitPrépayé ForfaitPrépayé { get; set; }

        public ModeleBatterie  ModeleBatterie { get; set; } 

    }
}

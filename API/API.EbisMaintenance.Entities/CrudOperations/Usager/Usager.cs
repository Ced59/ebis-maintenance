using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Usager
{
    class Usager
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string TelFixe { get; set; }

        public string TelMobile { get; set; }

        public Contrat Contrat { get; set; }

    }
}

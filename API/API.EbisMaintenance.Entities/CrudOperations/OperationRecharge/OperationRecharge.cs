using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
using System;
using System.Collections.Generic;

namespace API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie
{
    public class OperationRecharge : ModelBase
    {
        public DateTime DateHeureDebut { get; set; }

        public DateTime DateHeureFin { get; set; }

        public float NbKwHeures { get; set; }

        //TODO Voir si on lie directement la borne où on peut relier avec l'id
        public Borne Borne { get; set; }

        public string NoContrat { get; set; }

        //TODO voir si nécéssaire car avec liaison usager pas besoin

        //[JsonProperty(PropertyName = "prenom")]
        //public string Prenom { get; set; }

        //[JsonProperty(PropertyName = "nom")]
        //public string Nnom { get; set; }

        //TODO Voir si on lie directement la borne où on peut relier avec l'id
        public Usager Usager { get; set; }

        public List<Controle> Controle { get; set; }

        public bool DemandeEntretien { get; set; }
    }
}
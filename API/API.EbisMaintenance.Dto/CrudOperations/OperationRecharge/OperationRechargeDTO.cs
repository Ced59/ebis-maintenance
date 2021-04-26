using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using API.EbisMaintenance.Dto.CrudOperations.UsagerDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationRechargeDTO
{
    public class OperationRechargeDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "dateHeureDebut")]
        public DateTime DateHeureDebut { get; set; }

        [JsonProperty(PropertyName = "dateHeureFin")]
        public DateTime DateHeureFin { get; set; }

        [JsonProperty(PropertyName = "nbKwHeures")]
        public float NbKwHeures { get; set; }

        //TODO Voir si on lie directement la borne où on peut relier avec l'id
        [JsonProperty(PropertyName = "borne")]
        public BorneDTO Borne { get; set; }

        [JsonProperty(PropertyName = "noContrat")]
        public string NoContrat { get; set; }

        //TODO voir si nécéssaire car avec liaison usager pas besoin

        //[JsonProperty(PropertyName = "prenom")]
        //public string Prenom { get; set; }

        //[JsonProperty(PropertyName = "nom")]
        //public string Nnom { get; set; }

        //TODO Voir si on lie directement la borne où on peut relier avec l'id
        [JsonProperty(PropertyName = "usager")]
        public UsagerDTO.UsagerDTO Usager { get; set; }

        [JsonProperty(PropertyName = "controle")]
        public List<ControleDTO> Controle { get; set; }

        [JsonProperty(PropertyName = "demandeEntretien")]
        public bool DemandeEntretien { get; set; }

    }
}

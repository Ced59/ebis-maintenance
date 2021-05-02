using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationsRechargeDTO
{
    public class OperationRechargeDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "dateHeureDebut")]
        public DateTime DateHeureDebut { get; set; }

        [JsonProperty(PropertyName = "dateHeureFin")]
        public DateTime DateHeureFin { get; set; }

        [JsonProperty(PropertyName = "nbKwHeures")]
        public float NbKwHeures { get; set; }

        [JsonProperty(PropertyName = "borne")]
        public BorneDTO Borne { get; set; }

        [JsonProperty(PropertyName = "noContrat")]
        public string NoContrat { get; set; }

        [JsonProperty(PropertyName = "usager")]
        public UsagerDTO.UsagerDTO Usager { get; set; }

        [JsonProperty(PropertyName = "controle")]
        public List<ControleDTO> Controle { get; set; }

        [JsonProperty(PropertyName = "demandeEntretien")]
        public bool DemandeEntretien { get; set; }
    }
}
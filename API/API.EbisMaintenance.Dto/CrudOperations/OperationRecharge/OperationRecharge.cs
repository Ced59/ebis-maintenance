using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationRecharge
{
    class OperationRecharge
    {
        [JsonProperty(PropertyName = "dateHeureDebut")]
        public DateTime DateHeureDebut { get; set; }

        [JsonProperty(PropertyName = "dateHeureFin")]
        public DateTime DateHeureFin { get; set; }

        [JsonProperty(PropertyName = "nbKwHeures")]
        public float NbKwHeures { get; set; }

        [JsonProperty(PropertyName = "borne")]
        public Guid Borne { get; set; }

        [JsonProperty(PropertyName = "noContrat")]
        public string NoContrat { get; set; }

        [JsonProperty(PropertyName = "prenom")]
        public string Prenom { get; set; }

        [JsonProperty(PropertyName = "controle")]
        public List<ControleDTO> Controle { get; set; }

        [JsonProperty(PropertyName = "demandeEntretien")]
        public bool demandeEntretien { get; set; }

    }
}

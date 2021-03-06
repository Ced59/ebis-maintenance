using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.UsagerDTO
{
    public class UsagerDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "nom")]
        public string Nom { get; set; }

        [JsonProperty(PropertyName = "prenom")]
        public string Prenom { get; set; }

        [JsonProperty(PropertyName = "adresse")]
        public string Adresse { get; set; }

        [JsonProperty(PropertyName = "ville")]
        public string Ville { get; set; }

        [JsonProperty(PropertyName = "codePostal")]
        public string CodePostal { get; set; }

        [JsonProperty(PropertyName = "telFixe")]
        public string TelFixe { get; set; }

        [JsonProperty(PropertyName = "telMobile")]
        public string TelMobile { get; set; }

        [JsonProperty(PropertyName = "contrat")]
        public ContratDTO Contrat { get; set; }
    }
}
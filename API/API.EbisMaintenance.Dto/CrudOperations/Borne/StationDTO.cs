using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.Borne
{
    public class StationDTO
    {
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "adresseRue")]
        public string AdresseRue { get; set; }

        [JsonProperty(PropertyName = "adresseVille")]
        public string AdresseVille { get; set; }

        [JsonProperty(PropertyName = "codePostal")]
        public string CodePostal { get; set; }
    }
}
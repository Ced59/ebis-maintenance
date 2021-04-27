using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.EntretiensDTO
{
    public class ElementsVerifiesDTO
    {
        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }
    }
}
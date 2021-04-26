using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.Borne
{
    public class TypeChargeDTO
    {
        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "puissance")]
        public string Puissance { get; set; }
    }
}
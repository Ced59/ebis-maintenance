using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationsRechargeDTO
{
    public class ControleDTO
    {
        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "details")]
        public string Notes { get; set; }
    }
}
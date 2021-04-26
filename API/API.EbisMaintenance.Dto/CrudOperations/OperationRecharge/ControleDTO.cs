using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationRechargeDTO
{
    public class ControleDTO
    {
        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "détails")]
        public string Notes { get; set; }
    }
}
using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CrudOperations.UsagerDTO
{
    public class ForfaitPrepayeDTO
    {
        [JsonProperty(PropertyName = "soldesKwHeures")]
        public string SoldeKwHeures { get; set; }
    }
}
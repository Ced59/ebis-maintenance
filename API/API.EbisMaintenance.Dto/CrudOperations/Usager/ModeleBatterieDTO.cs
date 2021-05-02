using Newtonsoft.Json;

namespace API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie
{
    public class ModeleBatterieDTO
    {
        [JsonProperty(PropertyName = "fabricant")]
        public string Fabricant { get; set; }

        [JsonProperty(PropertyName = "capacite")]
        public float Capacite { get; set; }
    }
}
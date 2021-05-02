using Newtonsoft.Json;

namespace API.EbisMaintenance.Dto.CalculatedOperations.AverageElementFunctionnementsDTO
{
    public class ChangementElementsDTO
    {
        [JsonProperty(PropertyName = "element")]
        public string Element { get; set; }

        [JsonProperty(PropertyName = "nbreChangement")]
        public int NbreChangement { get; set; }
    }
}
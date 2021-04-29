using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CalculatedOperations.AverageElementFunctionnementsDTO
{
    public class AverageElementFunctionnementDTO
    {
        [JsonProperty(PropertyName = "nbreBorne")]
        public int NbreBorne { get; set; }

        [JsonProperty(PropertyName = "changementElements")]
        public List<ChangementElementsDTO> ChangementElements { get; set; }
    }
}

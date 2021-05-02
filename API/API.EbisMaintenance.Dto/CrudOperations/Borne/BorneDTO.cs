using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.EbisMaintenance.Dto.CrudOperations.BornesDTO
{
    public class BorneDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "dateMiseEnService")]
        public DateTime DateMiseEnService { get; set; }

        [JsonProperty(PropertyName = "dateDerniereRevision")]
        public DateTime DateDerniereRevision { get; set; }

        [JsonProperty(PropertyName = "station")]
        public StationDTO Station { get; set; }

        [JsonProperty(PropertyName = "typeCharge")]
        public List<TypeChargeDTO> TypeCharge { get; set; }
    }
}
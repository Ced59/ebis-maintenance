using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Usager
{
    class ForfaitPrépayéDTO
    {
        [JsonProperty(PropertyName = "soldesKwHeures")]
        public float SoldeKwHeures { get; set; }
    }
}

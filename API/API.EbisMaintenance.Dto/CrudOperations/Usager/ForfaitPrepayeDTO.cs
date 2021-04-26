using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.UsagerDTO
{
    public class ForfaitPrepayeDTO
    {
        [JsonProperty(PropertyName = "soldesKwHeures")]
        public string SoldeKwHeures { get; set; }
    }
}

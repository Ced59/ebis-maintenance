using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.OperationRecharge
{
    class ControleDTO
    {

        [JsonProperty(PropertyName = "libelle")]
        public string Libelle { get; set; }

        [JsonProperty(PropertyName = "détails")]
        public string Détails { get; set; }
    }
}

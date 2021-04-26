using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Usager
{
    class AbonnementDTO
    {

        [JsonProperty(PropertyName = "dateDebut")]
        public DateTime DateDebut { get; set; }

        [JsonProperty(PropertyName = "dateDebut")]
        public DateTime DateFin { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace API.EbisMaintenance.Dto.CrudOperations.UsagerDTO
{
    public class AbonnementDTO
    {
        [JsonProperty(PropertyName = "dateDebut")]
        public DateTime DateDebut { get; set; }

        [JsonProperty(PropertyName = "dateFin")]
        public DateTime DateFin { get; set; }
    }
}
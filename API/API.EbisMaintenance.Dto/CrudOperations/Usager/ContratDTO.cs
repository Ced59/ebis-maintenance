using API.EbisMaintenance.Entities.CrudOperations.UsagerEntitie;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.UsagerDTO
{
    public class ContratDTO
    {
        [JsonProperty(PropertyName = "dateContrat")]
        public DateTime DateContrat { get; set; }

        [JsonProperty(PropertyName = "noImmatriculation")]
        public string NoImmatriculation { get; set; }

        [JsonProperty(PropertyName = "abonnement")]
        public AbonnementDTO Abonnement { get; set; }

        [JsonProperty(PropertyName = "forfaitPrepaye")]
        public ForfaitPrepayeDTO ForfaitPrepaye { get; set; }

        [JsonProperty(PropertyName = "modeleBatterie")]
        public ModeleBatterieDTO ModeleBatterie { get; set; }
    }
}

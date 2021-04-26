using API.EbisMaintenance.Entities.CrudOperations.Usager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Usager
{
    class ContraDTO
    {
        [JsonProperty(PropertyName = "dateContrat")]
        public DateTime DateContrat { get; set; }

        [JsonProperty(PropertyName = "noImmatriculation")]
        public string NoImmatriculation { get; set; }


        [JsonProperty(PropertyName = "abonnement")]
        public AbonnementDTO Abonnement { get; set; }

        [JsonProperty(PropertyName = "forfaitPrépayé")]
        public ForfaitPrépayéDTO ForfaitPrépayé { get; set; }

        [JsonProperty(PropertyName = "ModeleBatterie")]

        public ModeleBatterieDTO ModeleBatterie { get; set; }
    }
}

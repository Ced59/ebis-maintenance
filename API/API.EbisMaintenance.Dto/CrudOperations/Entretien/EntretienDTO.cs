using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using API.EbisMaintenance.Dto.CrudOperations.IncidentsDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.EntretiensDTO
{
    public class EntretienDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "elementsVerifies")]
        public List<ElementsVerifiesDTO> ElementsVerifies { get; set; }

        [JsonProperty(PropertyName = "resolu")]
        public bool Resolu { get; set; }

        [JsonProperty(PropertyName = "incident")]
        public IncidentDTO Incident { get; set; }

        [JsonProperty(PropertyName = "borne")]
        public BorneDTO Borne { get; set; }

        [JsonProperty(PropertyName = "dateIntervention")]
        public DateTime DateIntervention { get; set; }
    }
}
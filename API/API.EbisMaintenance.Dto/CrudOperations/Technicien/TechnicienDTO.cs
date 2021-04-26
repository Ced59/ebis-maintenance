﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.Borne
{
    public class TechnicienDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "nom")]
        public DateTime Nom { get; set; }

        [JsonProperty(PropertyName = "prenom")]
        public DateTime Prenom { get; set; }

        [JsonProperty(PropertyName = "secteurGeographique")]
        public StationDTO SecteurGeographique { get; set; }

        [JsonProperty(PropertyName = "typeCharge")]
        public List<TypeChargeDTO> TypeCharge { get; set; }
    }
}
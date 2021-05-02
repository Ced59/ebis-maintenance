using API.EbisMaintenance.Dto.CrudOperations.BornesDTO;
using API.EbisMaintenance.Dto.CrudOperations.OperationsRechargeDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Dto.CrudOperations.IncidentsDTO
{
    public class IncidentDTO : ModelBaseDTO
    {
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [JsonProperty(PropertyName = "operationRecharge")]
        public OperationRechargeDTO OperationRecharge { get; set; }
    }
}
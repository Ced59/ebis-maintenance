using API.EbisMaintenance.Entities.CrudOperations.BorneEntitie;
using API.EbisMaintenance.Entities.CrudOperations.OperationRechargeEntitie;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.IncidentEntitie
{
    public class Incident : ModelBase
    {
        public string Details { get; set; }

        public OperationRecharge OperationRecharge { get; set; }
    }
}
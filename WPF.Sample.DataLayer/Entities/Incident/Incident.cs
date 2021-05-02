using System;
using System.Collections.Generic;
using System.Text;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;
using WPF.MonAppli.CoucheDonnees.Entities.OperationRechargeEntities;

namespace WPF.MonAppli.CoucheDonnees.Entities.IncidentEntitie
{
    public class Incident : ModelBase
    {
        public string Details { get; set; }

        public OperationRecharge OperationRecharge { get; set; }
    }
}
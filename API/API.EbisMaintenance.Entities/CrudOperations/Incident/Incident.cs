using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Incident
{
    class Incident
    {
        public Guid OperationRecharge { get; set; }

        public Guid NumeroBorne { get; set; }

        public Guid Technicien { get; set; }

        public bool Resolu { get; set; }

        public List<ElementVérifié> ElementVérifié { get; set; }
    }
}

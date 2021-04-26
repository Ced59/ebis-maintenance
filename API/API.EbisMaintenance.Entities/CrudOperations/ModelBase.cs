using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations
{
    public class ModelBase
    {
        public Guid Id { get; set; }

        public string Document { get; set; }
    }
}

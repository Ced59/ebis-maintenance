﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.EbisMaintenance.Entities.CrudOperations.Borne
{
    public class Technicien : ModelBase 
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string SecteurGeographique { get; set; }

    }

}
}
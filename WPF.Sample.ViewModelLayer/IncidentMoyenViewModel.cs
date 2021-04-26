using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Classes;

namespace WPF.MonAppli.CoucheViewModel
{
    public class IncidentMoyenViewModel : ViewModelBase
    {
        public IncidentMoyenViewModel()
        {
            AfficherMessageStatut("Nombre d'incident moyen par bornes");
        }
    }
}

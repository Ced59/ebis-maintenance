using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Classes;

namespace WPF.MonAppli.CoucheViewModel
{
    public class TopBornesFiablesViewModel : ViewModelBase
    {
        public TopBornesFiablesViewModel()
        {
            AfficherMessageStatut("Top 5 des bornes fiables");
        }
    }
}

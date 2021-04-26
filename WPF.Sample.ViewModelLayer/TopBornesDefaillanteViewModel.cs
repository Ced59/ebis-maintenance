using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Classes;

namespace WPF.MonAppli.CoucheViewModel
{
    public class TopBornesDefaillanteViewModel : ViewModelBase
    {
        public TopBornesDefaillanteViewModel()
        {
            AfficherMessageStatut("Top 5 des bornes défaillantes");
        }
    }
}

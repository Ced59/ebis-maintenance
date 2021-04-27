using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;
using WPF.MonAppli.CoucheDonnees.Models;

namespace WPF.MonAppli.CoucheViewModel
{
    public class ListeIncidentViewModel : ViewModelBase
    {
        public ListeIncidentViewModel()
        {
            AfficherMessageStatut("Liste des incidents");
        }

        public List<Borne> GetListBornes()
        {
            var requestBornes = new GetAllBornes();

            return requestBornes.LaunchRequestAsync();
        }
    }
}
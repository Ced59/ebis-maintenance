using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentEntitie;
using WPF.MonAppli.CoucheDonnees.Models;

namespace WPF.MonAppli.CoucheViewModel
{
    public class ListeIncidentViewModel : ViewModelBase
    {
        private List<Incident> allIncidents;
        public List<Incident> AllIncidents {
            get { return allIncidents; }
            set
            {
                allIncidents = value;
                RaisePropertyChanged("AllIncidents");
            } 
        }
        public ListeIncidentViewModel()
        {
            AfficherMessageStatut("Liste des incidents");
        }

        public void GetIncidents()
        {
            var requestIncidents = new GetAllIncidents();

            AllIncidents = requestIncidents.LaunchRequest();
        }
    }
}
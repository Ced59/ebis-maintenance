using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentEntitie;
using WPF.MonAppli.CoucheDonnees.Entities.OperationRechargeEntities;
using WPF.MonAppli.CoucheDonnees.Models;

namespace WPF.MonAppli.CoucheViewModel
{
    public class ListeIncidentViewModel : ViewModelBase
    {
        private List<Incident> Incidents;
        public List<Incident> AllIncidents {
            get { return Incidents; }
            set
            {
                Incidents = value;
                RaisePropertyChanged("AllIncidents");
            } 
        }
        public ListeIncidentViewModel()
        {
            AfficherMessageStatut("Liste des incidents");
        }

        public List<Borne> GetListBornes()
        {
            var requestBornes = new GetAllBornes();

            return requestBornes.LaunchRequestAsync();
        }

        public List<OperationRecharge> GetOperationRecharges()
        {
            var requestOperationRecharges = new GetAllOperationRecharge();

            return requestOperationRecharges.LaunchRequestAsync();
        }

        public List<Incident> GetIncidents()
        {
            var requestIncidents = new GetAllIncidents();

            return requestIncidents.LaunchRequestAsync();
        }
    }
}
using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;

namespace WPF.MonAppli.CoucheViewModel
{
    public class TopElementsDefectiveViewModel : ViewModelBase
    {
        private List<StatElementDefectueux> topFiveElementsWithIncident;

        public TopElementsDefectiveViewModel()
        {
            AfficherMessageStatut("Top 5 des bornes défaillantes");
        }

        public List<StatElementDefectueux> TopFiveElementsWithIncidents
        {
            get { return topFiveElementsWithIncident; }
            set
            {
                topFiveElementsWithIncident = value;
                RaisePropertyChanged("TopFiveElementsWithIncidents");
            }
        }

        public void getElementDefective()
        {
            var request = new GetTopFiveElementsWithIncidentStatistics();
            TopFiveElementsWithIncidents = request.LaunchRequest();
        }
    }
}
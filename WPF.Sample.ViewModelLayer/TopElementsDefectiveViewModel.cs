using Common.Classes;
using WPF.MonAppli.CoucheDonnees.Entities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;

namespace WPF.MonAppli.CoucheViewModel
{
    public class TopElementsDefectiveViewModel : ViewModelBase
    {
        private TopFiveElementsWithIncident topFiveElementsWithIncident;
        public TopElementsDefectiveViewModel()
        {
            AfficherMessageStatut("Top 5 des bornes défaillantes");
        }

        public TopFiveElementsWithIncident TopFiveElementsWithIncidents
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
            var request = new GetTopFiveElementsWithIncidentStatistics(5);
            TopFiveElementsWithIncidents = request.LaunchRequest();

        }
    }
}
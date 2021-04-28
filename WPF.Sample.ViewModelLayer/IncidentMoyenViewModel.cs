using Common.Classes;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentsMonthlyAverageEntities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;

namespace WPF.MonAppli.CoucheViewModel
{
    public class IncidentMoyenViewModel : ViewModelBase
    {
        private IncidentsMonthlyAverage incidentsMonthlyAverage;

        public IncidentsMonthlyAverage IncidentsMonthlyAverage
        {
            get { return incidentsMonthlyAverage; }
            set
            {
                incidentsMonthlyAverage = value;
                RaisePropertyChanged("IncidentsMonthlyAverage");
            }
        }

        public IncidentMoyenViewModel()
        {
            AfficherMessageStatut("Nombre d'incidents moyen par mois");
        }

        public void GetStatistics()
        {
            var request = new GetIncidentsMonthlyStatistics(5);

            IncidentsMonthlyAverage = request.LaunchRequest();
        }
    }
}
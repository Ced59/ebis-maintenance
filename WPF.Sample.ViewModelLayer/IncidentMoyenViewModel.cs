using Common.Classes;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentsMonthlyAverageEntities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace WPF.MonAppli.CoucheViewModel
{
    public class IncidentMoyenViewModel : ViewModelBase
    {
        private IncidentsMonthlyAverage incidentsMonthlyAverage;
        private ChartValues<float> chartValuesBinding;

        public IncidentsMonthlyAverage IncidentsMonthlyAverage
        {
            get { return incidentsMonthlyAverage; }
            set
            {
                incidentsMonthlyAverage = value;
                RaisePropertyChanged("IncidentsMonthlyAverage");
            }
        }

        public ChartValues<float> ChartValuesBinding
        {
            get { return chartValuesBinding; }
            set
            {
                chartValuesBinding = value;
                RaisePropertyChanged("ChartValuesBinding");
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

            ChartValuesBinding = new ChartValues<float>();

            foreach (var incident in incidentsMonthlyAverage.MonthlyIncidentCount)
            {
                ChartValuesBinding.Add(incident.NbreIncidentMonthly);
            }
        }
    }
}
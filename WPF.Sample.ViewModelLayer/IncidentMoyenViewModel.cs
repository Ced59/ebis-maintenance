using Common.Classes;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentsMonthlyAverageEntities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Linq;

namespace WPF.MonAppli.CoucheViewModel
{
    public class IncidentMoyenViewModel : ViewModelBase
    {
        private IncidentsMonthlyAverage incidentsMonthlyAverage;
        private ChartValues<float> chartValuesBinding;
        private int maxNbIncidentInOneMonth;

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

        public int MaxNbIncidentInOneMonth
        {
            get { return maxNbIncidentInOneMonth; }
            set
            {
                maxNbIncidentInOneMonth = value;
                RaisePropertyChanged("MaxNbIncidentInOneMonth");
            }
        }

        public void GetStatistics()
        {
            var request = new GetIncidentsMonthlyStatistics(5);

            IncidentsMonthlyAverage = request.LaunchRequest();

            MaxNbIncidentInOneMonth = (int)IncidentsMonthlyAverage.MonthlyIncidentCount.Max(x => x.NbreIncidentMonthly);

            ChartValuesBinding = new ChartValues<float>();

            foreach (var incident in incidentsMonthlyAverage.MonthlyIncidentCount)
            {
                ChartValuesBinding.Add(incident.NbreIncidentMonthly);
            }
        }
    }
}
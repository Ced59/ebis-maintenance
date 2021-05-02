using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;

namespace WPF.MonAppli.CoucheViewModel
{
    public class TopElementsReliableViewModel : ViewModelBase
    {
        private List<StatElementDefectueux> topFiveReliableElements;
        public TopElementsReliableViewModel()
        {
            AfficherMessageStatut("Top 5 des bornes fiables");
        }

        public List<StatElementDefectueux> TopFiveReliableElements
        {
            get { return topFiveReliableElements; }
            set
            {
                topFiveReliableElements = value;
                RaisePropertyChanged("TopFiveReliableElements");
            }
        }

        public void getElementReliable()
        {
            var request = new TopElementsFiablesStatistics();
            TopFiveReliableElements = request.LaunchRequest();
        }
    }
}
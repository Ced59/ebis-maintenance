using Common.Classes;
using System;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities.AverageElementFunctionnementEntities;
using WPF.MonAppli.CoucheDonnees.Entities.AverageElementFunctionnementsEntities;
using WPF.MonAppli.CoucheDonnees.Models.Statistics;

namespace WPF.MonAppli.CoucheViewModel
{
    public class FonctionnementMoyenViewModel : ViewModelBase
    {
        private AverageElementFunctionnement averageElementFunctionnement;
        private List<AverageTimeFunctionnement> averageFunctionnement;
        public FonctionnementMoyenViewModel()
        {
            AfficherMessageStatut("Fonctionnement moyen des bornes");
        }

        public AverageElementFunctionnement AverageElementFunctionnement
        {
            get { return averageElementFunctionnement; }
            set
            {
                averageElementFunctionnement = value;
                RaisePropertyChanged("AverageElementFunctionnement");
            }
        }

        public List<AverageTimeFunctionnement> AverageFunctionnement
        {
            get { return averageFunctionnement; }
            set
            {
                averageFunctionnement = value;
                RaisePropertyChanged("AverageFunctionnement");
            }
        }

        public void GetAverageElementFunctionnement()
        {
            var request = new AverageElementFunctionnementsStatistics();
            AverageElementFunctionnement = request.LaunchRequest();

            AverageFunctionnement = new List<AverageTimeFunctionnement>();

            foreach(var element in AverageElementFunctionnement.ChangementElements)
            {
                AverageFunctionnement.Add(new AverageTimeFunctionnement
                {
                    Element = element.Element,
                    AverageNbJours = (float)Math.Round((double)(5*((float)(5*365*AverageElementFunctionnement.NbreBorne)/(float)(5*365*(AverageElementFunctionnement.NbreBorne + element.NbreChangement)))), 2) + " Jours"
                });
            }
        }
    }
}
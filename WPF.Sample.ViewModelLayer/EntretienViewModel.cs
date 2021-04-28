using Common.Classes;
using System.Collections.Generic;
using WPF.MonAppli.CoucheDonnees.Entities.EntretienEntities;
using WPF.MonAppli.CoucheDonnees.Models;

namespace WPF.MonAppli.CoucheViewModel
{
    public class EntretienViewModel : ViewModelBase
    {
        private List<Entretien> allEntretiens;
        public List<Entretien> AllEntretiens
        {
            get { return allEntretiens; }
            set
            {
                allEntretiens = value;
                RaisePropertyChanged("AllEntretiens");
            }
        }
        public EntretienViewModel()
        {
            AfficherMessageStatut("Liste des Entretiens");
        }

        public void GetEntretiens()
        {
            var requestEntretiens = new GetAllEntretiens();

            AllEntretiens = requestEntretiens.LaunchRequest();
        }
    }
}
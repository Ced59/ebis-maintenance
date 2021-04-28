using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheDonnees.Entities.IncidentEntitie;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for EntretienControl.xaml
    /// </summary>
    public partial class EntretienControl : UserControl
    {
        private EntretienViewModel viewModel;
        public List<Incident> AllIncident { get; set; }


        public EntretienControl()
        {
            InitializeComponent();
            viewModel = (EntretienViewModel)this.Resources["viewModel"];
            viewModel.GetEntretiens();
        }


        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheDonnees.Entities.BorneEntities;
using WPF.MonAppli.CoucheDonnees.Entities.OperationRechargeEntities;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for ListeIncidentControl.xaml
    /// </summary>
    public partial class ListeIncidentControl : UserControl
    {
        private ListeIncidentViewModel viewModel;
        public List<Borne> AllBornes { get; set; }
        public List<OperationRecharge> AllOperationRecharge { get; set; }

        public ListeIncidentControl()
        {
            InitializeComponent();
            viewModel = (ListeIncidentViewModel)this.Resources["viewModel"];
            viewModel.GetIncidents();
        }


        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
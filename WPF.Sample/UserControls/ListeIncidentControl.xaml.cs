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

            AllBornes = viewModel.GetListBornes();

            AllOperationRecharge = viewModel.GetOperationRecharges();

            var test = AllBornes;

            var test2 = AllOperationRecharge;
        }


        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
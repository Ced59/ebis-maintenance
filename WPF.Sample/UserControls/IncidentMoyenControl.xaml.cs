using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for IncidentMoyenControl.xaml
    /// </summary>
    public partial class IncidentMoyenControl : UserControl
    {
        private IncidentMoyenViewModel viewModel;

        public IncidentMoyenControl()
        {
            InitializeComponent();
            viewModel = (IncidentMoyenViewModel)this.Resources["viewModel"];
            viewModel.GetStatistics();
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
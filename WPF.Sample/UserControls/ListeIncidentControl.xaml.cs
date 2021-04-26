using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for ListeIncidentControl.xaml
    /// </summary>
    public partial class ListeIncidentControl : UserControl
    {
        private ListeIncidentViewModel viewModel;

        public ListeIncidentControl()
        {
            InitializeComponent();
            viewModel = (ListeIncidentViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
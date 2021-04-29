using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for FonctionnementMoyenControl.xaml
    /// </summary>
    public partial class FonctionnementMoyenControl : UserControl
    {
        private FonctionnementMoyenViewModel viewModel;

        public FonctionnementMoyenControl()
        {
            InitializeComponent();
            viewModel = (FonctionnementMoyenViewModel)this.Resources["viewModel"];
            viewModel.GetAverageElementFunctionnement();
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
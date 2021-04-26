using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for TopBornesFiablesControl.xaml
    /// </summary>
    public partial class TopBornesFiablesControl : UserControl
    {
        private TopBornesFiablesViewModel viewModel;

        public TopBornesFiablesControl()
        {
            InitializeComponent();
            viewModel = (TopBornesFiablesViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
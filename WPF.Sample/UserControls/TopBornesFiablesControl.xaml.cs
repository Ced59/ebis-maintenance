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
        private TopElementsFiablesViewModel viewModel;

        public TopBornesFiablesControl()
        {
            InitializeComponent();
            viewModel = (TopElementsFiablesViewModel)this.Resources["viewModel"];
        }

        private void FermerBouton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Fermer();
        }
    }
}
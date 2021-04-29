using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
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
    }
}
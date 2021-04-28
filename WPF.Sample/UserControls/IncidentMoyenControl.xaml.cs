//using System.Windows;
//using System.Windows.Controls;
//using WPF.MonAppli.CoucheViewModel;

//namespace WPF.MonAppli.UserControls
//{
//    /// <summary>
//    /// Interaction logic for IncidentMoyenControl.xaml
//    /// </summary>
//    public partial class IncidentMoyenControl : UserControl
//    {
//        private IncidentMoyenViewModel viewModel;

//        public IncidentMoyenControl()
//        {
//            InitializeComponent();
//            viewModel = (IncidentMoyenViewModel)this.Resources["viewModel"];
//            viewModel.GetStatistics();
//        }

//        private void FermerBouton_Click(object sender, RoutedEventArgs e)
//        {
//            viewModel.Fermer();
//        }
//    }
//}

using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using WPF.MonAppli.CoucheViewModel;

namespace WPF.MonAppli.UserControls
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
    /// </summary>
    public partial class IncidentMoyenControl : UserControl
    {
        private IncidentMoyenViewModel viewModel;
        private double _lastLecture;
        private double _trend;

        public IncidentMoyenControl()
        {
            InitializeComponent();

            viewModel = (IncidentMoyenViewModel)this.Resources["viewModel"];
            viewModel.GetStatistics();
        }
    }
}
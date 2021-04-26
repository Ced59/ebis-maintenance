﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF.MonAppli.CoucheViewModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

using System;
using System.Windows.Controls;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UnusualSettledBetsView : UserControl
    {
        public UnusualSettledBetsView()
        {
            InitializeComponent();
            DataContext = new UnusualSettledBetsViewModel();
            Loaded += UnusualSettledBets_Loaded;
        }

        void UnusualSettledBets_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = (UnusualSettledBetsViewModel)DataContext;
            viewModel.RefreshData();
        }
    }
}

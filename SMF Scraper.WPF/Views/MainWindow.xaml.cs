using SMF_Scraper.WPF.ViewModels;
using System.Windows;

namespace SMF_Scraper.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel { get; set; }



        public MainWindow(MainViewModel viewModel)
        {
            ViewModel = viewModel;

            DataContext = ViewModel;

            InitializeComponent();
        }
    }
}

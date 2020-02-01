using System.Windows;

namespace WpfApp3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private MainWindow() {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel) : this() {
            this.DataContext = viewModel;
        }
    }
}

using System.Windows;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Creates a new instance of <see cref="MainWindow"/> and set the <see cref="FrameworkElement.DataContext"/>
        /// with a new instance of <see cref="ViewModels.ViewModelShelf"/>.
        /// </summary>
        public MainWindow()
        {
            DataContext = new ViewModels.ViewModelShelf();

            InitializeComponent();
        }
    }
}

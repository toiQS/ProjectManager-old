using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        
        public StatusWindow()
        {
            InitializeComponent();
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddStatusWindow addStatusWindow = new AddStatusWindow();
            addStatusWindow.ShowDialog();
        }

        private void ViewEditButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}

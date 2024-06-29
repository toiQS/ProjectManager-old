using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddStatusWindow.xaml
    /// </summary>
    public partial class AddStatusWindow : Window
    {
        
        public AddStatusWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AddStatusButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

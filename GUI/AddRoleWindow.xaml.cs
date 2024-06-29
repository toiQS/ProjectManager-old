using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddRoleWindow.xaml
    /// </summary>
    public partial class AddRoleWindow : Window
    {
        public AddRoleWindow()
        {
            InitializeComponent();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

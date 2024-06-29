using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ViewRoleWindow.xaml
    /// </summary>
    public partial class ViewRoleWindow : Window
    {
        
        public ViewRoleWindow(int id)
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {

        public RoleWindow()
        {
            InitializeComponent();
             // Ensure RoleBUS is instantiated here
            
        }

       

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            var addRoleWindow = new AddRoleWindow();
            addRoleWindow.ShowDialog();
           
        }

        private void ViewRoleButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void BackToHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

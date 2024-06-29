using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    public partial class ProjectWindow : Window
    {
       

        public ProjectWindow()
        { 
            InitializeComponent();
           
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            NewProjectView newProjectView = new NewProjectView();
            newProjectView.Closed += (s, args) => Show(); // Ensure to show this window again after closing newProjectView
            newProjectView.Show();
        }

        private void ViewEditProject_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => Show(); // Ensure to show this window again after closing mainWindow
            mainWindow.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // You can implement logic here if needed when selection changes in the ListView
        }
    }
}

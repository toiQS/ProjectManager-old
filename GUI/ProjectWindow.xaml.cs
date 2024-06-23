using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
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
            newProjectView.Show();
        }

        private void ViewProject_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectDetailView projectDetailView = new ProjectDetailView();
            projectDetailView.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}

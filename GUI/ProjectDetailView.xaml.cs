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
    /// Interaction logic for ProjectDetailView.xaml
    /// </summary>
    public partial class ProjectDetailView : Window
    {
        private readonly int _projectId;    
        public ProjectDetailView(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectWindow projectWindow = new ProjectWindow();
            projectWindow.Show();
        }


        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            EditProjectView projectView = new EditProjectView();
            projectView.Show();
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageProgress_Click(object sender, RoutedEventArgs e)
        {
            ManageTasksView projectView = new ManageTasksView();
            projectView.Show();
        }

        private void ManageMembers_Click(object sender, RoutedEventArgs e)
        {
            ProjectMembersView projectMembersView = new ProjectMembersView();
            projectMembersView.Show();
        }
    }
}

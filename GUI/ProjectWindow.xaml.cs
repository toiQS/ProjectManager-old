using Models;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    public partial class ProjectWindow : Window
    {
       
        private readonly Project_Services project_Services = new Project_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly Status_Services status_Services = new Status_Services();
        public ProjectWindow()
        { 
            InitializeComponent();
            var data = project_Services.GetProjects()
                .Select(x => new ProjectResponse()
                {
                    EndAt = x.EndAt,
                    //PersonalCreated = user_Services.GetUser(x.UserID).UserName,
                    ProjectName = x.ProjectName,
                    StartAt = x.StartAt,
                    Status = status_Services.GetStatus(x.StatusID).StatusName,
                });
            ProjectListView.ItemsSource  = data;
            
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
            if (ProjectListView.SelectedItem is Project project_selected)
            {
                ProjectDetailView projectDetailView = new ProjectDetailView(project_selected.ProjectID);
                projectDetailView.Show();
            }
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => Show(); // Ensure to show this window again after closing mainWindow
            mainWindow.Show();
        }
    }
}

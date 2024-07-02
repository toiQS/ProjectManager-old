using Models;
using Services;
using System.Linq;
using System.Windows;

namespace GUI
{
    public partial class ProjectWindow : Window
    {
        private readonly Project_Services _projectServices = new Project_Services();
        private readonly User_Services _userServices = new User_Services();
        private readonly Status_Services _statusServices = new Status_Services();

        public ProjectWindow()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            var data = _projectServices.GetProjects()
                .Select(x => new ProjectResponse()
                {
                    ProjectID = x.ProjectID,
                    EndAt = x.EndAt,
                    PersonalCreated = _userServices.GetUser(x.UserID)?.UserName ?? "Unknown",
                    ProjectName = x.ProjectName,
                    StartAt = x.StartAt,
                    Status = _statusServices.GetStatus(x.StatusID)?.StatusName ?? "Unknown"
                }).ToList();

            ProjectListView.ItemsSource = data;
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            NewProjectView newProjectView = new NewProjectView();
            newProjectView.Closed += (s, args) => { Show(); LoadProjects(); };
            Hide();
            newProjectView.Show();
        }

        private void ViewEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse projectSelected)
            {
                ProjectDetailView projectDetailView = new ProjectDetailView(projectSelected.ProjectID);
                //projectDetailView.Closed += (s, args) => { Show(); LoadProjects(); };
                Hide();
                projectDetailView.Show();
            }
            else
            {
                MessageBox.Show("Please select a project from the list.", "No Project Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Closed += (s, args) => Show();
            Hide();
            mainWindow.Show();
        }
    }
}

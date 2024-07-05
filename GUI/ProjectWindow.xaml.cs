using Models;
using Services;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
    public partial class ProjectWindow : Window
    {
        private readonly Project_Services _projectServices;
        private readonly User_Services _userServices;
        private readonly Status_Services _statusServices;

        public ProjectWindow()
        {
            InitializeComponent();

            _projectServices = new Project_Services();
            _userServices = new User_Services();
            _statusServices = new Status_Services();

            LoadProjects();
        }

        private void LoadProjects()
        {
            try
            {
                var projects = _projectServices.GetProjects()
                    .Select(x => new ProjectResponse
                    {
                        ProjectID = x.ProjectID,
                        EndAt = x.EndAt,
                        PersonalCreated = _userServices.GetUser(x.UserID)?.UserName ?? "Unknown",
                        ProjectName = x.ProjectName,
                        StartAt = x.StartAt,
                        Status = _statusServices.GetStatus(x.StatusID)?.StatusName ?? "Unknown"
                    }).ToList();

                ProjectListView.ItemsSource = projects;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading projects: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<NewProjectView>(() => new NewProjectView());
        }

        private void ViewEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse projectSelected)
            {
                ShowWindow<ProjectDetailView>(() => new ProjectDetailView(projectSelected.ProjectID));
            }
            else
            {
                MessageBox.Show("Please select a project from the list.", "No Project Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<MainWindow>(() => new MainWindow());
        }

        private void ShowWindow<T>(Func<T> windowConstructor) where T : Window
        {
            try
            {
                var newWindow = windowConstructor.Invoke();
                newWindow.Owner = this;
                newWindow.Closed += (s, args) => ShowMainWindow();
                Hide();
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowMainWindow()
        {
            Show();
        }
    }
}

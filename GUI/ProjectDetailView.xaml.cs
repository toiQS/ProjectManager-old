using Models;
using Services;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ProjectDetailView.xaml
    /// </summary>
    public partial class ProjectDetailView : Window
    {
        private readonly int _projectId;
        private readonly Project_Services project_Services = new Project_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly Status_Services status_Services = new Status_Services();

        public ProjectDetailView(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadProjectDetails();
        }

        private void LoadProjectDetails()
        {
            try
            {
                var data = project_Services.GetProject(_projectId);
                if (data == null) throw new Exception("Project data is null");

                var convert_data = new ProjectResponseDetail()
                {
                    ProjectID = data.ProjectID,
                    ProjectName = data.ProjectName,
                    CreateAt = data.CreateAt,
                    EndAt = data.EndAt,
                    Quantity_Member_Requied = data.Quantity_Member_Requied,
                    PersonalCreated = user_Services.GetUser(data.UserID)?.UserName ?? "Unknown",
                    ProjectDescription = data.ProjectDescription,
                    ProjectInfo = data.ProjectInfo,
                    StartAt = data.StartAt,
                    Status = status_Services.GetStatus(data.StatusID)?.StatusName ?? "Unknown",
                };

                ProjectNameTextBox.Text = convert_data.ProjectName;
                StartDatePicker.SelectedDate = convert_data.StartAt;
                EndDatePicker.SelectedDate = convert_data.EndAt;
                InfoTextBox.Text = convert_data.ProjectInfo;
                DescriptionTextBox.Text = convert_data.ProjectDescription;
                CreationDatePicker.SelectedDate = convert_data.CreateAt;
                CreatorTextBox.Text = convert_data.PersonalCreated;

                var statusList = status_Services.GetStatuses().Select(s => s.StatusName).ToList();
                StatusComboBox.ItemsSource = statusList;
                StatusComboBox.SelectedItem = statusList.FirstOrDefault(status => status == convert_data.Status);

                MemberCountTextBox.Text = convert_data.Quantity_Member_Requied.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading project details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(() => new EditProjectView(_projectId));
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = project_Services.DeleteProject(_projectId);
                if (result)
                {
                    MessageBox.Show("Project deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ShowMainWindow();
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to delete project.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting project: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ManageProgress_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(() => new ManageTasksView(_projectId));
        }

        private void ManageMembers_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(() => new ProjectMembersView(_projectId));
        }

        // Generic method to show a window
        private void ShowWindow<T>(Func<T> windowConstructor) where T : Window
        {
            try
            {
                var newWindow = windowConstructor();
                newWindow.Owner = this;
                newWindow.Closed += (s, args) => Show();
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
            try
            {
                var mainWindow = new ProjectWindow();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening main window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

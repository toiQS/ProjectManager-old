using GUI.Member_Form;
using GUI.Task_Form;
using Services._services;
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

namespace GUI.Project_Form
{
    /// <summary>
    /// Interaction logic for ProjectDetailView.xaml
    /// </summary>
    public partial class ProjectDetailView : Window
    {
        private readonly int _userId;
        private readonly int _projectId;
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly StatusServices statusServices = new StatusServices();
        private readonly UserServices userServices = new UserServices();

        /// <summary>
        /// Initializes a new instance of the ProjectDetailView class.
        /// Loads project data and sets visibility of update button based on user role.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="userId">The ID of the logged-in user.</param>
        public ProjectDetailView(int projectId, int userId)
        {
            InitializeComponent();
            _userId = userId;
            _projectId = projectId;
            var user_root = LoadData();
            if (userId != user_root)
            {
                UpdateButton.Visibility = Visibility.Hidden;
                UpdateButton.IsEnabled = false;
            }
            else
            {
                UpdateButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Opens a new window of type T and hides the current window.
        /// Shows the main window again when the new window is closed.
        /// </summary>
        /// <typeparam name="T">The type of the window to be opened.</typeparam>
        /// <param name="windowConstructor">The constructor function for the new window.</param>
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

        /// <summary>
        /// Shows the main window.
        /// </summary>
        private void ShowMainWindow()
        {
            Show();
        }

        /// <summary>
        /// Loads the project data and populates the labels with project information.
        /// Returns the ID of the user who created the project.
        /// </summary>
        /// <returns>The ID of the user who created the project.</returns>
        private int LoadData()
        {
            var data = projectServices.GetProject(_projectId);
            ProjectNameLabel.Text = data.ProjectName;
            ProjectInfoLabel.Text = data.ProjectInfo;
            DescriptionLabel.Text = data.ProjectDescription;
            StartDateLabel.Text = data.StartAt.ToString();
            EndDateLabel.Text = data.EndAt.ToString();
            CreatedDateLabel.Text = data.CreateAt.ToString();
            StatusLabel.Text = statusServices.GetStatus(data.StatusID).StatusName;
            CreatedDateLabel.Text = userServices.GetUser(data.UserID).UserName;
            return data.UserID;
        }

        /// <summary>
        /// Handles the Click event of the BackButton.
        /// Closes the current window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the ManageTasksButton.
        /// </summary>
        private void ManageTasksButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<TaskWindow>(() => new TaskWindow(_projectId,_userId));
        }

        /// <summary>
        /// Handles the Click event of the ManageMembersButton.
        /// Opens the MemberWindow to manage project members.
        /// </summary>
        private void ManageMembersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<MemberWindow>(() => new MemberWindow(_projectId, _userId));
        }

        /// <summary>
        /// Handles the Click event of the UpdateButton.
        /// Opens the UpdateProjectView window to update project details.
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<UpdateProjectView>(() => new UpdateProjectView(_projectId));
        }
    }
}

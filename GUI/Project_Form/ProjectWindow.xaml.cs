using Models;
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private readonly int _userID;
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly StatusServices statusServices = new StatusServices();
        private readonly UserServices userServices = new UserServices();

        /// <summary>
        /// Initializes a new instance of the ProjectWindow class.
        /// Loads project data and sets the user ID.
        /// </summary>
        /// <param name="userId">The user ID of the logged-in user.</param>
        public ProjectWindow(int userId)
        {
            InitializeComponent();
            LoadData();
            _userID = userId;
        }

        /// <summary>
        /// Handles the Click event of the ViewButton.
        /// Opens the ProjectDetailView window for the selected project.
        /// </summary>
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse project_selected)
            {
                ShowWindow<ProjectDetailView>(() => new ProjectDetailView(project_selected.ProjectID, _userID));
            }
            else
            {
                MessageBox.Show("Please choose an item", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of the CreateButton.
        /// Opens the AddProjectWindow window to create a new project.
        /// </summary>
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddProjectWindow>(() => new AddProjectWindow(_userID));
        }

        /// <summary>
        /// Handles the Click event of the EditButton.
        /// Opens the ProjectDetailView window for editing the selected project.
        /// </summary>
        private void EditButton_Click(object sender, object e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse project_selected)
            {
                ShowWindow<ProjectDetailView>(() => new ProjectDetailView(project_selected.ProjectID, _userID));
            }
            else
            {
                MessageBox.Show("Please choose a project", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of the ExitButton.
        /// Closes the current window.
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the project data and populates the ProjectListView.
        /// Displays a warning message if data cannot be loaded.
        /// </summary>
        private void LoadData()
        {
            var data = projectServices.GetProjects()
                .Select(x => new ProjectResponse()
                {
                    EndAt = x.EndAt,
                    PersonalCreated = userServices.GetUser(x.UserID).UserName,
                    ProjectID = x.ProjectID,
                    ProjectName = x.ProjectName,
                    ProjectDescription = x.ProjectDescription,
                    StartAt = x.StartAt,
                    Status = statusServices.GetStatus(x.UserID).StatusName,
                });

            if (data == null)
            {
                MessageBox.Show("Can't get data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ProjectListView.ItemsSource = data;
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

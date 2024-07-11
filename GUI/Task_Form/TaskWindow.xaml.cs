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

namespace GUI.Task_Form
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private readonly int _projectId;
        private readonly int _userId;
        private readonly TaskInProjectServices taskInProjectServices = new TaskInProjectServices();
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();

        /// <summary>
        /// Initializes a new instance of the TaskWindow class.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="userId">The ID of the user.</param>
        public TaskWindow(int projectId, int userId)
        {
            InitializeComponent();
            _projectId = projectId;
            _userId = userId;
            LoadData();

            // Check if the user is a member of the project and has appropriate permissions
            var isMember = memberInProjectServices.GetMemberInProject(userId, _projectId);
            if (isMember != null)
            {
                var person_create_id = projectServices.GetProject(_projectId).UserID;
                if (isMember.RoleID != 1 || userId != person_create_id)
                {
                    // Hide the AddTaskButton if the user is not authorized
                    AddTaskButton.Visibility = Visibility.Hidden;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the AddTaskButton.
        /// Opens the AddTaskProjectWindow to add a new task to the project.
        /// </summary>
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddTaskProjectWindow>(() => new AddTaskProjectWindow(_projectId));
        }

        /// <summary>
        /// Handles the Click event of the ViewTaskButton.
        /// Opens the TaskDetailWindow to view details of the selected task.
        /// </summary>
        private void ViewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListView.SelectedItems is TaskInProjectResponse task_selected)
            {
                ShowWindow<TaskDetailWindow>(() => new TaskDetailWindow(task_selected.TaskID, _userId, _projectId));
            }
            else
            {
                MessageBox.Show("Please select a task", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
        /// Loads the tasks associated with the project into the TaskListView.
        /// </summary>
        private void LoadData()
        {
            var data = taskInProjectServices.GetTasksInProject(_projectId)
                .Select(x => new TaskInProjectResponse()
                {
                    TaskName = x.TaskName,
                    TaskLevelName = taskLevelServices.GetTaskLevel(x.TaskLevelID).TaskName,
                    EndAt = x.EndAt,
                    StartAt = x.StartAt,
                    TaskDescription = x.TaskDescription,
                    TaskID = x.TaskID,
                });

            if (data != null)
            {
                TaskListView.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("Can't load data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Helper method to show a new window and handle its closure.
        /// </summary>
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
        /// Shows the main window again after another window is closed.
        /// </summary>
        private void ShowMainWindow()
        {
            Show();
        }
    }
}

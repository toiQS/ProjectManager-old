using GUI.Member_In_Task_Form;
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
    /// Interaction logic for TaskDetailWindow.xaml
    /// </summary>
    public partial class TaskDetailWindow : Window
    {
        private readonly int _projectId;
        private readonly int _taskId;
        private readonly int _userId;
        private readonly TaskInProjectServices taskInProjectServices = new TaskInProjectServices();
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();

        /// <summary>
        /// Initializes a new instance of the TaskDetailWindow class.
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="projectId">The ID of the project.</param>
        public TaskDetailWindow(int taskId, int userId, int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            _taskId = taskId;
            _userId = userId;
            LoadData();
            LoadTaskLevel();

            // Check if the current user is authorized to edit or delete the task
            var isMember = memberInProjectServices.GetMemberInProject(userId, _projectId);
            if (isMember != null)
            {
                var person_create_id = projectServices.GetProject(_projectId).UserID;
                if (isMember.RoleID != 1 || userId != person_create_id)
                {
                    // Hide edit and delete buttons if not authorized
                    DeleteButton.Visibility = Visibility.Hidden;
                    SaveButton.Visibility = Visibility.Hidden;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the SaveButton.
        /// Updates the task details if the input is valid.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var task_name = TaskNameTextBox.Text;
            var task_description = TaskDescriptionTextBox.Text;
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            var task_level_name = TaskLevelComboBox.SelectedValue.ToString();

            // Validate the selected dates
            if (start_at < DateTime.Now || end_at < DateTime.Now || start_at > end_at)
            {
                MessageBox.Show("Please select a valid date range", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate the task level selection
            if (task_level_name == "Node")
            {
                MessageBox.Show("Please select a task level for the task", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get the task level ID
            var task_level_id = taskLevelServices.GetByName(task_level_name);

            // Update the task details
            var result = taskInProjectServices.UpdateTask(_taskId, task_name, task_description, _projectId, start_at, end_at, task_level_id);

            if (result)
            {
                MessageBox.Show("Task updated successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update the task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteButton.
        /// Deletes the task from the project.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = taskInProjectServices.RemoveTask(_taskId);

            if (result)
            {
                MessageBox.Show("Task deleted successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to delete the task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton.
        /// Closes the current window.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the task details into the form controls.
        /// </summary>
        private void LoadData()
        {
            ProjectNameTextBlock.Text = projectServices.GetProject(_projectId).ProjectName;
            var data_task = taskInProjectServices.GetTask(_taskId);

            TaskNameTextBox.Text = data_task.TaskName;
            TaskDescriptionTextBox.Text = data_task.TaskDescription;
            StartDatePicker.SelectedDate = data_task.StartAt;
            EndDatePicker.SelectedDate = data_task.EndAt;
            CreateAtTextBlock.Text = data_task.CreateAt.ToString();
            TaskLevelComboBox.SelectedValue = taskLevelServices.GetTaskLevel(data_task.TaskLevelID).TaskName;
        }

        /// <summary>
        /// Loads the task levels into the TaskLevelComboBox.
        /// </summary>
        private void LoadTaskLevel()
        {
            var data_task_level = taskLevelServices.GetTaskLevels();
            var array_data_task_level = new List<string>()
            {
                "Node"
            };

            foreach (var item in data_task_level)
            {
                array_data_task_level.Add(item.TaskName);
            }

            TaskLevelComboBox.ItemsSource = array_data_task_level;
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

        private void ManageMembersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<MemberTaskForm>(() => new MemberTaskForm(_taskId,_projectId,_userId));
        }
    }
}

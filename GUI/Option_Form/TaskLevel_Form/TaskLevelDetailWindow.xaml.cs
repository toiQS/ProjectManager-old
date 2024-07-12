using Services._services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GUI.Option_Form.TaskLevel_Form
{
    /// <summary>
    /// Interaction logic for TaskLevelDetailWindow.xaml
    /// </summary>
    public partial class TaskLevelDetailWindow : Window
    {
        private readonly int _taskLevelId;
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();

        public TaskLevelDetailWindow(int taskLevelId)
        {
            InitializeComponent();
            _taskLevelId = taskLevelId;
            LoadTaskLevel();
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the SaveButton.
        /// Updates the task level based on the input provided.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var task_level_parent_name = InitialTaskLevelComboBox.SelectedValue as string;
            var task_level_name = TaskLevelNameTextBox.Text;
            var task_level_info = TaskLevelInfoTextBox.Text;
            bool result;

            // Validate input
            if (string.IsNullOrEmpty(task_level_name) || string.IsNullOrEmpty(task_level_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update task level with or without parent
            if (task_level_parent_name != "Node")
            {
                var task_level_parent_id = taskLevelServices.GetByName(task_level_parent_name);
                result = taskLevelServices.UpdateTaskLevel(_taskLevelId, task_level_name, task_level_info, task_level_parent_id);
            }
            else
            {
                result = taskLevelServices.UpdateTaskLevel(_taskLevelId, task_level_name, task_level_info, null);
            }

            // Show appropriate message based on the result
            if (result)
            {
                MessageBox.Show("Task level updated successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error updating task level", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the DeleteButton.
        /// Deletes the task level.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = taskLevelServices.RemoveTaskLevel(_taskLevelId);

            // Show appropriate message based on the result
            if (result)
            {
                MessageBox.Show("Task level deleted successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error deleting task level", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the current window.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the list of task levels into the InitialTaskLevelComboBox.
        /// </summary>
        private void LoadTaskLevel()
        {
            var data = taskLevelServices.GetTaskLevels();
            var taskLevelNames = new List<string>
            {
                "Node"
            };

            foreach (var item in data)
            {
                taskLevelNames.Add(item.TaskName);
            }

            InitialTaskLevelComboBox.ItemsSource = taskLevelNames;
        }

        /// <summary>
        /// Loads the data of the specific task level into the form fields.
        /// </summary>
        private void LoadData()
        {
            var data = taskLevelServices.GetTaskLevel(_taskLevelId);
            TaskLevelNameTextBox.Text = data.TaskName;
            TaskLevelInfoTextBox.Text = data.TaskInfo;
            InitialTaskLevelComboBox.SelectedValue = taskLevelServices.GetTaskLevelParent(data.TaskParentID)?.TaskName ?? "Node";
        }
    }
}

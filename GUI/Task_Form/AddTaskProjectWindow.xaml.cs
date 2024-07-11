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
    /// Interaction logic for AddTaskProjectWindow.xaml
    /// </summary>
    public partial class AddTaskProjectWindow : Window
    {
        private readonly int _projectId;
        private readonly TaskInProjectServices taskInProjectServices = new TaskInProjectServices();
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();

        /// <summary>
        /// Initializes a new instance of the AddTaskProjectWindow class.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        public AddTaskProjectWindow(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadData();
        }

        /// <summary>
        /// Handles the Click event of the SaveButton.
        /// Saves the new task to the project if the input is valid.
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

            // Add the task to the project
            var result = taskInProjectServices.AddTask(task_name, task_description, _projectId, start_at, end_at, task_level_id);

            if (result)
            {
                MessageBox.Show("Task added successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add the task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
        /// Loads the project name and task levels into the form controls.
        /// </summary>
        private void LoadData()
        {
            // Set the project name
            ProjectNameTextBlock.Text = projectServices.GetProject(_projectId).ProjectName;

            // Get task levels and add them to the combo box
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
    }
}

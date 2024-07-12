using Services._services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GUI.Option_Form.TaskLevel_Form
{
    /// <summary>
    /// Interaction logic for AddTaskLevelWindow.xaml
    /// </summary>
    public partial class AddTaskLevelWindow : Window
    {
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();

        public AddTaskLevelWindow()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the AddButton.
        /// Adds a new task level based on the input provided.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var task_level_parent_name = InitialTaskLevelComboBox.SelectedValue as string;
            var task_level_name = TaskLevelNameTextBox.Text;
            var task_level_info = TaskLevelInfoTextBox.Text;
            bool result;

            if (string.IsNullOrEmpty(task_level_name) || string.IsNullOrEmpty(task_level_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add task level with or without parent
            if (task_level_name != "Node")
            {
                var task_level_parent_id = taskLevelServices.GetByName(task_level_parent_name);
                result = taskLevelServices.AddTaskLevel(task_level_name, task_level_info, task_level_parent_id);
            }
            else
            {
                result = taskLevelServices.AddTaskLevel(task_level_name, task_level_info, null);
            }

            // Show appropriate message based on the result
            if (result)
            {
                MessageBox.Show("Task level added successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error adding task level", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
        /// Loads data of task levels into the InitialTaskLevelComboBox.
        /// </summary>
        private void LoadData()
        {
            var data = taskLevelServices.GetTaskLevels();
            var array_task_level_name = new List<string>
            {
                "Node"
            };

            foreach (var item in data)
            {
                array_task_level_name.Add(item.TaskName);
            }

            InitialTaskLevelComboBox.ItemsSource = array_task_level_name;
        }
    }
}

using Models;
using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.TaskLevel_Form
{
    /// <summary>
    /// Interaction logic for TaskLevelWindow.xaml
    /// </summary>
    public partial class TaskLevelWindow : Window
    {
        private readonly TaskLevelServices taskLevelServices = new TaskLevelServices();

        public TaskLevelWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddTaskLevelWindow>(() => new AddTaskLevelWindow());
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskLevelListView.SelectedItem is Task_Level task_selected)
            {
                ShowWindow<TaskLevelDetailWindow>(() => new TaskLevelDetailWindow(task_selected.TaskLevelID));
            }
            else
            {
                MessageBox.Show("Please select a task level in the list.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            try
            {
                var data = taskLevelServices.GetTaskLevels();
                TaskLevelListView.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading task levels: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            LoadData(); // Refresh data when returning to the main window
        }
    }
}

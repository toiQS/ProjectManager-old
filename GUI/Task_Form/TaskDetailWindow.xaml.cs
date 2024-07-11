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
        public TaskDetailWindow(int taskId, int userId, int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            _taskId = taskId;
            _userId = userId;
            LoadData();
            LoadTaskLevel();
            var isMember = memberInProjectServices.GetMemberInProject(userId, _projectId) ?? null;
            if (isMember != null)
            {
                var person_create_id = projectServices.GetProject(_projectId).UserID;
                if (isMember.RoleID != 1 || userId != person_create_id)
                {
                    DeleteButton.Visibility = Visibility.Hidden;
                    SaveButton.Visibility = Visibility.Hidden;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var task_name = TaskNameTextBox.Text;
            var task_description = TaskDescriptionTextBox.Text;
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            var task_level_name = TaskLevelComboBox.SelectedValue.ToString();
            if (start_at < DateTime.Now || end_at < DateTime.Now || start_at > end_at)
            {
                MessageBox.Show("Please select date again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (task_level_name == "Node")
            {
                MessageBox.Show("Please select a task level for task", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var task_level_id = taskLevelServices.GetByName(task_level_name);
                var result = taskInProjectServices
                    .UpdateTask(_taskId, task_name, task_description, _projectId, start_at, end_at, task_level_id);
                if (result)
                {
                    MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Close();
                }
                else
                {
                    MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ManageMembersButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = taskInProjectServices.RemoveTask(_taskId);
            if (result)
            {
                MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
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

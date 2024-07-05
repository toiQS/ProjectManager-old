using Services;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for TaskDetailView.xaml
    /// </summary>
    public partial class TaskDetailView : Window
    {
        private readonly int _task_project_id;
        private readonly Task_In_Project_Services task_In_Project_Services = new Task_In_Project_Services();
        private readonly Task_Level_Services task_Level_Services = new Task_Level_Services();
        public TaskDetailView(int task_project_id)
        {
            InitializeComponent();
            _task_project_id = task_project_id;
            var data = task_In_Project_Services.GetTask(task_project_id);
            TitleTextBox.Text = data.TaskName;
            InfoTextBox.Text = data.TaskDescription;
            StartDatePicker.SelectedDate = data.StartAt;
            EndDatePicker.SelectedDate = data.EndAt;

            LevelTaskNameComboBox.SelectedItem = task_Level_Services.GetTaskLevel(data.TaskID).TaskName;
            var load_data_task = task_Level_Services.GetTask_Level();
            var array_data_task = new List<string>()
            {
                "Node"
            };
            foreach (var role in load_data_task)
            {
                array_data_task.Add(role.TaskName);
            }
            LevelTaskNameComboBox.ItemsSource = array_data_task;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void UpdateTask_Click(object sender, RoutedEventArgs e)
        {
            var task_name = TitleTextBox.Text;
            var task_description = InfoTextBox.Text;
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            var level_name = LevelTaskNameComboBox.SelectedItem.ToString();
            if (level_name == "Node")
            {
                MessageBox.Show("");
            }
            else
            {
                var level_id = task_Level_Services.GetTaskIdByText(task_name);
                var result = task_In_Project_Services.UpdateTask(_task_project_id,task_name, task_description,
                    start_at, end_at, level_id);
                if (result)
                {
                    MessageBox.Show("");
                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}

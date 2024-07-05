using Models;
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
    /// Interaction logic for ManageTasksView.xaml
    /// </summary>
    public partial class ManageTasksView : Window
    {
        private readonly Task_In_Project_Services task_In_Project_Services = new Task_In_Project_Services();
        private readonly Task_Level_Services task_Level_Services = new Task_Level_Services();
        private readonly Project_Services project_Services = new Project_Services();
        private readonly int _projectID;

        public ManageTasksView(int projectID)
        {
            _projectID = projectID;
            InitializeComponent();
            var data = task_In_Project_Services
                .GetTasks(_projectID)
                .Select(x => new Task_Project_Response()
                {
                    TaskID = x.TaskID,
                    TaskName = x.TaskName,
                    StartAt = x.StartAt,
                    EndAt = x.EndAt,
                    ProjectName = project_Services.GetProject(x.ProjectID).ProjectName,
                    TaskLevelName = task_Level_Services.GetTaskLevel(x.TaskID).TaskName,
                    TaskDescription = x.TaskDescription,
                });
            TasksDataGrid.ItemsSource = data;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

            AddTaskView addTaskView = new AddTaskView(_projectID) ;
            addTaskView.ShowDialog();
        }

        private void ViewTask_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is Task_Project_Response task_selected)
            {
                TaskDetailView taskDetailView = new TaskDetailView(task_selected.TaskID);
                taskDetailView.Show();
            }
            
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is Task_Project_Response task_selected)
            {
                var result = task_In_Project_Services.DeleteTask(task_selected.TaskID);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

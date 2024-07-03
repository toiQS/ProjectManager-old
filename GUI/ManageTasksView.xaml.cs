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
        public ManageTasksView(int projectID)
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddEditTaskView addEditTaskView = new AddEditTaskView();
            addEditTaskView.Show();
        }

        private void ViewTask_Click(object sender, RoutedEventArgs e)
        {
            TaskDetailView taskDetailView = new TaskDetailView();
            taskDetailView.Show();
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        private readonly Role_Services role_Services = new Role_Services();
        private readonly Task_In_Project_Services task_In_Project_Services = new Task_In_Project_Services();
        private int _project_id;
        public AddTaskView(int projectID)
        {
            InitializeComponent();
            _project_id = projectID;
            var load_data_role = role_Services.GetRoles();
            var array_data_role = new List<string>()
            {
                "Node"
            };
            foreach (var role in load_data_role)
            {
                array_data_role.Add(role.RoleName);
            }
            LevelTaskIDComboBox.SelectedItem = array_data_role[0];
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            string task_name = TitleTextBox.Text;
            string task_description = InfoTextBox.Text;
            string task_level_selected = LevelTaskIDComboBox.SelectedItem.ToString();
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            if (task_level_selected == "Node")
            {
                MessageBox.Show("");
            }
            else
            {
                var role_id = role_Services.GetRoleByText(task_level_selected);
                var result = task_In_Project_Services.AddTask(task_name, task_description, start_at, end_at, role_id,_project_id);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}

using Services._services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.Project_Form
{
    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        private readonly int _userId;
        private readonly ProjectServices projectServices = new ProjectServices();
        public AddProjectWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var project_name = ProjectNameTextBox.Text;
            var project_info = ProjectInfoTextBox.Text;
            var project_description = ProjectDescriptionTextBox.Text;
            var max_member = Convert.ToInt32(MaxMembersTextBox.Text);
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            if (start_at < DateTime.Now || end_at < DateTime.Now || start_at > end_at)
            {
                MessageBox.Show("Please select date again","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                if (start_at == DateTime.Now)
                {
                    var result = projectServices.AddProject(project_name, project_info, project_description, start_at, end_at, max_member,2, _userId);
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
                if(start_at > DateTime.Now)
                {
                    var result = projectServices.AddProject(project_name, project_info, project_description, start_at, end_at, max_member, 4, _userId);
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
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

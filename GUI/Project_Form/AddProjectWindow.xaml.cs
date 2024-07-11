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

        /// <summary>
        /// Initializes a new instance of the AddProjectWindow class.
        /// </summary>
        /// <param name="userId">The ID of the user creating the project.</param>
        public AddProjectWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        /// <summary>
        /// Handles the Click event of the SaveButton.
        /// Saves the new project with the provided details.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var project_name = ProjectNameTextBox.Text;
            var project_info = ProjectInfoTextBox.Text;
            var project_description = ProjectDescriptionTextBox.Text;
            var max_member = Convert.ToInt32(MaxMembersTextBox.Text);
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;

            // Check if the selected dates are valid
            if (start_at < DateTime.Now || end_at < DateTime.Now || start_at > end_at)
            {
                MessageBox.Show("Please select date again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                bool result;
                // Add project based on start date
                if (start_at == DateTime.Now)
                {
                    result = projectServices.AddProject(project_name, project_info, project_description, start_at, end_at, max_member, 2, _userId);
                }
                else // start_at > DateTime.Now
                {
                    result = projectServices.AddProject(project_name, project_info, project_description, start_at, end_at, max_member, 4, _userId);
                }

                // Show appropriate message based on the result
                if (result)
                {
                    MessageBox.Show("Confirm", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error saving project", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton.
        /// Closes the current window without saving.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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

namespace GUI.Project_Form
{
    /// <summary>
    /// Interaction logic for UpdateProjectView.xaml
    /// </summary>
    public partial class UpdateProjectView : Window
    {
        private readonly int _projectId;
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly StatusServices statusServices = new StatusServices();

        /// <summary>
        /// Initializes a new instance of the UpdateProjectView class.
        /// Loads project data and status options.
        /// </summary>
        /// <param name="projectID">The ID of the project to be updated.</param>
        public UpdateProjectView(int projectID)
        {
            InitializeComponent();
            _projectId = projectID;
            LoadData();
            LoadStatus();
        }

        /// <summary>
        /// Handles the Click event of the BackButton.
        /// Closes the current window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the UpdateButton.
        /// Updates the project with the provided details.
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var project_name = ProjectNameTextBox.Text;
            var project_info = ProjectInfoTextBox.Text;
            var project_description = DescriptionTextBox.Text;
            var max_member = Convert.ToInt32(MaxMembersTextBox.Text);
            var start_at = StartDatePicker.SelectedDate.Value;
            var end_at = EndDatePicker.SelectedDate.Value;
            var status_name = StatusComboBox.SelectedValue.ToString();

            if (status_name == "Node")
            {
                MessageBox.Show("Please select a status again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (start_at < DateTime.Now || end_at < DateTime.Now || start_at > end_at)
                {
                    MessageBox.Show("Please select date again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var status_id = statusServices.GetByName(status_name);
                    if (status_id == 0)
                    {
                        MessageBox.Show("Can't get status id", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        var result = projectServices.UpdateProject(_projectId, project_name, project_info, project_description, start_at, end_at, max_member, status_id);
                        if (result)
                        {
                            MessageBox.Show("Confirm", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Loads the project data into the form fields.
        /// </summary>
        private void LoadData()
        {
            var data = projectServices.GetProject(_projectId);
            ProjectNameTextBox.Text = data.ProjectName;
            StartDatePicker.SelectedDate = data.StartAt;
            EndDatePicker.SelectedDate = data.EndAt;
            ProjectInfoTextBox.Text = data.ProjectInfo;
            DescriptionTextBox.Text = data.ProjectDescription;
            StatusComboBox.SelectedValue = statusServices.GetStatus(data.StatusID).StatusName;
            MaxMembersTextBox.Text = data.Quantity_Member_Requied.ToString();
        }

        /// <summary>
        /// Loads the status options into the StatusComboBox.
        /// </summary>
        private void LoadStatus()
        {
            var data = statusServices.GetStatuss();
            var data_array_name = new List<string> { "Node" };

            foreach (var item in data)
            {
                data_array_name.Add(item.StatusName);
            }

            StatusComboBox.ItemsSource = data_array_name;
        }
    }
}

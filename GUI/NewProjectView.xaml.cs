using Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GUI
{
    public partial class NewProjectView : Window
    {
        private readonly Status_Services status_Services = new Status_Services();
        private readonly Project_Services project_Services = new Project_Services();

        public NewProjectView()
        {
            InitializeComponent();
            InitializeStatusComboBox();
        }

        private void InitializeStatusComboBox()
        {
            try
            {
                var statuses = status_Services.GetStatuses();
                var statusNames = new List<string>();
                foreach (var status in statuses)
                {
                    statusNames.Add(status.StatusName);
                }
                StatusComboBox.ItemsSource = statusNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statuses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var project_name = txtProjectName.Text;
                var projet_info = txtProjectInfo.Text;
                var project_description = txtProjectDescription.Text;
                var start_at = dpStartAt.SelectedDate.Value;
                var end_at = dpEndAt.SelectedDate.Value;
                var quantity_member = Convert.ToInt32(txtMember.Text);
                var status_name = StatusComboBox.SelectedItem?.ToString(); // Ensure SelectedItem is not null
                var user_id = 1;

                if (status_name == "Node")
                {
                    MessageBox.Show("Please select a valid status.", "Invalid Status", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var status_id = status_Services.GetIdByText(status_name);
                var result = project_Services.AddProject(project_name, projet_info,
                    project_description, start_at, end_at, quantity_member, status_id, user_id);

                if (result)
                {
                    MessageBox.Show("Project added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to add project.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving project: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

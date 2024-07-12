using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.Statuss_Form
{
    /// <summary>
    /// Interaction logic for StatusDetailWindow.xaml
    /// </summary>
    public partial class StatusDetailWindow : Window
    {
        private readonly int _statusId;
        private readonly StatusServices statusServices = new StatusServices();

        public StatusDetailWindow(int statusId)
        {
            InitializeComponent();
            _statusId = statusId;
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the SaveButton.
        /// Updates the status with the modified name and info.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var status_name = StatusNameTextBox.Text;
            var status_info = StatusInfoTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(status_name) || string.IsNullOrEmpty(status_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update status
            var result = statusServices.UpdateStatus(_statusId, status_name, status_info);
            if (result)
            {
                MessageBox.Show("Status updated successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error updating status", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the DeleteButton.
        /// Removes the status from the system.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = statusServices.RemoveStatus(_statusId);
            if (result)
            {
                MessageBox.Show("Status removed successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error removing status", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the window without saving any changes.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads data of the selected status into the form.
        /// </summary>
        private void LoadData()
        {
            var data = statusServices.GetStatus(_statusId);
            if (data != null)
            {
                StatusNameTextBox.Text = data.StatusName;
                StatusInfoTextBox.Text = data.StatusInfo;
            }
            else
            {
                MessageBox.Show("Error loading status data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
    }
}

using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.Statuss_Form
{
    /// <summary>
    /// Interaction logic for AddStatusWindow.xaml
    /// </summary>
    public partial class AddStatusWindow : Window
    {
        private readonly StatusServices statusServices = new StatusServices();

        public AddStatusWindow()
        {
            InitializeComponent();
            StatusNameTextBox.Text = string.Empty;
            StatusInfoTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Handles the click event for the AddButton.
        /// Adds a new status based on the provided status name and info.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var status_name = StatusNameTextBox.Text;
            var status_info = StatusInfoTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(status_name) || string.IsNullOrEmpty(status_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add status
            var result = statusServices.AddStatus(status_name, status_info);
            if (result)
            {
                MessageBox.Show("Status added successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error adding status", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the window without adding a new status.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.Role_Form
{
    /// <summary>
    /// Interaction logic for AddRoleWindow.xaml
    /// </summary>
    public partial class AddRoleWindow : Window
    {
        private readonly RoleServices roleServices = new RoleServices();

        public AddRoleWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the AddButton.
        /// Adds a new role based on the provided role name and info.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var role_name = RoleNameTextBox.Text;
            var role_info = RoleInfoTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(role_name) || string.IsNullOrEmpty(role_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add role
            var result = roleServices.AddRole(role_name, role_info);
            if (result)
            {
                MessageBox.Show("Role added successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error adding role", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the window without adding a new role.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.Role_Form
{
    /// <summary>
    /// Interaction logic for RoleDetailWinform.xaml
    /// </summary>
    public partial class RoleDetailWinform : Window
    {
        private readonly RoleServices roleServices = new RoleServices();
        private readonly int _roleId;

        public RoleDetailWinform(int roleId)
        {
            InitializeComponent();
            _roleId = roleId;
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the SaveButton.
        /// Updates the role information and closes the window if successful.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var role_name = RoleNameTextBox.Text;
            var role_info = RoleInfoTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(role_name) || string.IsNullOrEmpty(role_info))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update role information
            var result = roleServices.UpdateRole(_roleId, role_name, role_info);
            if (result)
            {
                MessageBox.Show("Role updated successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error updating role", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the click event for the DeleteButton.
        /// Removes the role and closes the window if successful.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirm deletion with user
            var confirmResult = MessageBox.Show("Are you sure you want to delete this role?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmResult == MessageBoxResult.Yes)
            {
                var result = roleServices.RemoveRole(_roleId);
                if (result)
                {
                    MessageBox.Show("Role deleted successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error deleting role", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the window without making any changes.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads role data into the form fields.
        /// </summary>
        private void LoadData()
        {
            var data = roleServices.GetRole(_roleId);
            if (data != null)
            {
                RoleNameTextBox.Text = data.RoleName;
                RoleInfoTextBox.Text = data.RoleInfo;
            }
            else
            {
                MessageBox.Show("Role not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
    }
}

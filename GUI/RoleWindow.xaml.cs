using BUS._role;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {

        public RoleWindow()
        {
            InitializeComponent();
             // Ensure RoleBUS is instantiated here
            LoadRoles();
        }

        public void LoadRoles()
        {
            try
            {
                RoleBUS roleBUS = new RoleBUS();
                var roles = roleBUS.GetRoles();
                RolesListView.ItemsSource = roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load roles: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            var addRoleWindow = new AddRoleWindow();
            addRoleWindow.ShowDialog();
            LoadRoles(); // Reload roles after adding
        }

        private void ViewRoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RolesListView.SelectedItem is Role selectedRole)
            {
                var id = selectedRole.RoleID;
                ViewRoleWindow viewRoleWindow = new ViewRoleWindow(id);
                viewRoleWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a role to view.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void BackToHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

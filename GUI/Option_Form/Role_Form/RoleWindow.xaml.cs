using Models;
using Services._services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Option_Form.Role_Form
{
    /// <summary>
    /// Interaction logic for RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {
        private readonly RoleServices roleServices = new RoleServices();

        public RoleWindow()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the AddButton.
        /// Opens a new window to add a role.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddRoleWindow>(() => new AddRoleWindow());
        }

        /// <summary>
        /// Handles the click event for the ViewButton.
        /// Opens a new window to view details of the selected role.
        /// </summary>
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (RoleListView.SelectedItem is Role role_selected)
            {
                ShowWindow<RoleDetailWinform>(() => new RoleDetailWinform(role_selected.RoleID));
            }
        }

        /// <summary>
        /// Handles the click event for the BackButton.
        /// Closes the current window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads role data from the database and populates the RoleListView.
        /// </summary>
        private void LoadData()
        {
            var data = roleServices.GetRoles();
            if (data == null)
            {
                MessageBox.Show("Failed to load role data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RoleListView.ItemsSource = data;
        }

        /// <summary>
        /// Opens a new window of type T and hides the current window.
        /// Shows the main window again when the new window is closed.
        /// </summary>
        /// <typeparam name="T">The type of the window to be opened.</typeparam>
        /// <param name="windowConstructor">The constructor function for the new window.</param>
        private void ShowWindow<T>(Func<T> windowConstructor) where T : Window
        {
            try
            {
                var newWindow = windowConstructor.Invoke();
                newWindow.Owner = this;
                newWindow.Closed += (s, args) => ShowMainWindow();
                Hide();
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Shows the main window.
        /// </summary>
        private void ShowMainWindow()
        {
            Show();
        }
    }
}

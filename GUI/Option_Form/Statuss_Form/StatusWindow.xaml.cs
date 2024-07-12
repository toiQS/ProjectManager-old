using Models;
using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.Statuss_Form
{
    /// <summary>
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        private readonly StatusServices statusServices = new StatusServices();

        public StatusWindow()
        {
            InitializeComponent();
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the AddButton.
        /// Opens the AddStatusWindow for adding a new status.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddStatusWindow>(() => new AddStatusWindow());
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
        /// Handles the click event for the ViewButton.
        /// Opens the StatusDetailWindow for viewing details of the selected status.
        /// </summary>
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusListView.SelectedItem is Status status_selected)
            {
                ShowWindow<StatusDetailWindow>(() => new StatusDetailWindow(status_selected.StatusID));
            }
            else
            {
                MessageBox.Show("Please select a status from the list", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Loads data of statuses into the StatusListView.
        /// </summary>
        private void LoadData()
        {
            var data = statusServices.GetStatuss();
            if (data == null)
            {
                MessageBox.Show("Failed to load status data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                StatusListView.ItemsSource = data;
            }
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

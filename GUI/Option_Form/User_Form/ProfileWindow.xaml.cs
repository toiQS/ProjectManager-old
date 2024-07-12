using Services._services;
using System;
using System.Windows;

namespace GUI.Option_Form.User_Form
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private readonly int _userId;
        private readonly UserServices userServices = new UserServices();

        public ProfileWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
            LoadData();
        }

        /// <summary>
        /// Handles the click event for the SaveButton.
        /// Updates the user profile with the provided information.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var user_email = EmailTextBox.Text;
            var user_name = UserNameTextBox.Text;
            var password = PasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(user_email))
            {
                MessageBox.Show("Please fill all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = userServices.UpdateUser(_userId, user_name, user_email, password);

            // Show appropriate message based on the result
            if (result)
            {
                MessageBox.Show("Profile updated successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error updating profile", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles the click event for the CancelButton.
        /// Closes the current window.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the user data into the form fields.
        /// </summary>
        private void LoadData()
        {
            var data = userServices.GetUser(_userId);

            if (data != null)
            {
                UserNameTextBox.Text = data.UserName;
                UserIDTextBlock.Text = data.UserID.ToString();
                PasswordTextBox.Text = data.Password;
                EmailTextBox.Text = data.Email;
            }
            else
            {
                MessageBox.Show("Error loading user data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
    }
}

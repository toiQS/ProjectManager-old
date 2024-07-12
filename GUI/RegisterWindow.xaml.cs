using Services._services;
using System;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserServices userServices = new UserServices();

        /// <summary>
        /// Initializes a new instance of the RegisterWindow class.
        /// </summary>
        public RegisterWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the BackButton.
        /// Closes the current registration window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the RegisterButton.
        /// Attempts to register a new user with the provided email, username, and password.
        /// </summary>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var user_name = UserNameTextBox.Text;
            var password = PasswordBox.Password;

            // Check if any of the fields are empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email, User Name, or Password was null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Check if the user already exists (using email and password)
                var check_data = userServices.Login(email, password);
                if (check_data)
                {
                    MessageBox.Show("An account already exists with this email and password", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    // Attempt to add the new user
                    var result = userServices.AddUser(user_name, email, password);
                    if (result)
                    {
                        MessageBox.Show("Registration successful", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close(); // Close the registration window after successful registration
                    }
                    else
                    {
                        MessageBox.Show("Registration failed", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}

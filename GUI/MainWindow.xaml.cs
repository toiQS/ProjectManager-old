using GUI.Project_Form;
using Services._services;
using System.Windows;

namespace GUI
{
    public partial class MainWindow : Window
    {
        private readonly UserServices userServices = new UserServices();

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the LoginButton.
        /// Attempts to log in the user with the provided email and password.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email or Password was null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = userServices.Login(email, password);
                if (result)
                {
                    // If login successful, navigate to the ProjectWindow
                    ShowWindow<ProjectWindow>(() => new ProjectWindow(userServices.GetByEmail(email)));
                }
                else
                {
                    MessageBox.Show("Login failed", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the RegisterButton.
        /// Opens the RegisterWindow for user registration.
        /// </summary>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<RegisterWindow>(() => new RegisterWindow());
        }

        /// <summary>
        /// Helper method to show a new window and handle its closure.
        /// </summary>
        /// <typeparam name="T">Type of the window to show.</typeparam>
        /// <param name="windowConstructor">Function to create an instance of the window.</param>
        private void ShowWindow<T>(Func<T> windowConstructor) where T : Window
        {
            try
            {
                var newWindow = windowConstructor.Invoke();
                newWindow.Owner = this;
                newWindow.Closed += (s, args) => ShowMainWindow(); // Shows main window after child window closes
                Hide(); // Hides the main window while child window is open
                newWindow.Show(); // Shows the child window
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Shows the main window again after another window is closed.
        /// </summary>
        private void ShowMainWindow()
        {
            Show(); // Shows the main window
        }
    }
}

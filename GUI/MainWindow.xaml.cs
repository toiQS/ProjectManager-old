using GUI.Project_Form;
using Services._services;
using System.Windows;

namespace GUI
{
    public partial class MainWindow : Window
    {
        private readonly UserServices userServices = new UserServices();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email or Password war null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var result = userServices.Login(email, password);
                if (result)
                {
                    ShowWindow<ProjectWindow>(() => new ProjectWindow(userServices.GetByEmail(email)));
                }
                else
                {
                    MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for registration
            ShowWindow<RegisterWindow>(() => new RegisterWindow());
        }

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

        private void ShowMainWindow()
        {
            Show();
        }
    }
}

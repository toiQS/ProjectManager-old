using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Navigate to the Project Window
        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<ProjectWindow>();
        }

        // Navigate to the Role Window
        private void RoleButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<RoleWindow>();
        }

        // Navigate to the Status Window
        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<StatusWindow>();
        }

        // Navigate to the Task Level Window
        private void TaskLevelButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<TaskLevelsWindow>();
        }

        // Handle logout button click
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        // Generic method to show a window
        private void ShowWindow<T>() where T : Window, new()
        {
            try
            {
                var newWindow = new T
                {
                    Owner = this
                };
                newWindow.Show();
                newWindow.Closed += (s, args) => ShowMainWindow();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Show the Main Window
        private void ShowMainWindow()
        {
            Show();
        }
    }
}

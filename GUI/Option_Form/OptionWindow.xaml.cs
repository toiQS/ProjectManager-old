using GUI.Option_Form.Role_Form;
using GUI.Option_Form.Statuss_Form;
using GUI.Option_Form.TaskLevel_Form;
using GUI.Option_Form.User_Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI.Option_Form
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        private readonly int _userId;
        public OptionWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void ManageTaskLevels_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<TaskLevelWindow>(() => new TaskLevelWindow());
        }

        private void ManageRoles_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<RoleWindow>(() => new RoleWindow());
        }

        private void ManageStatus_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<StatusWindow>(() => new StatusWindow());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<ProfileWindow>(() => new ProfileWindow(_userId));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

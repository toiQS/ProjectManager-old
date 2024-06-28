using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectWindow projectWindow = new ProjectWindow();
            projectWindow.Show();
        }

        private void RoleButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            RoleWindow roleWindow = new RoleWindow();
            roleWindow.Show();
        }

        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            StatusWindow statusWindow = new StatusWindow();
            statusWindow.Show();
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            ViewProfileWindow profileWindow = new ViewProfileWindow();
            profileWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TaskLevelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TaskLevelsWindow taskLevelsWindow = new TaskLevelsWindow(); 
            taskLevelsWindow.Show();
        }
    }
}
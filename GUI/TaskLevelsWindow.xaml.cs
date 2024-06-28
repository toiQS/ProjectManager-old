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

namespace GUI
{
    /// <summary>
    /// Interaction logic for TaskLevelsWindow.xaml
    /// </summary>
    public partial class TaskLevelsWindow : Window
    {
        public TaskLevelsWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           AddTaskLevelWindow addTaskLevelWindow = new AddTaskLevelWindow();
            addTaskLevelWindow.ShowDialog();
        }

        private void ViewEditButton_Click(object sender, RoutedEventArgs e)
        {
            ViewEditTaskLevelWindow view = new ViewEditTaskLevelWindow();
            view.ShowDialog();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

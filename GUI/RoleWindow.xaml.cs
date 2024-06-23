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
    /// Interaction logic for RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {
        public RoleWindow()
        {
            InitializeComponent();
        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            AddRoleWindow roleWindow = new AddRoleWindow();
            roleWindow.ShowDialog();
        }

        private void ViewRoleButton_Click(object sender, RoutedEventArgs e)
        {
            ViewRoleWindow roleWindow = new ViewRoleWindow();
            roleWindow.ShowDialog();    
        }

        private void BackToHomeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

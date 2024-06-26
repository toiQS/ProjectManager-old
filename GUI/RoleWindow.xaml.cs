using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

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
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load roles: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

using BUS._role;
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
    /// Interaction logic for AddRoleWindow.xaml
    /// </summary>
    public partial class AddRoleWindow : Window
    {
        public AddRoleWindow()
        {
            InitializeComponent();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AddRoleButton_Click(object sender, RoutedEventArgs e)
        {
            string rolename = RoleNameTextBox.Text;
            string roleinfo = RoleInfoTextBox.Text;
            if(string.IsNullOrEmpty(rolename) || string.IsNullOrEmpty(roleinfo))
            {
                MessageBox.Show("Please input a new role.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            RoleBUS roleBUS = new RoleBUS();
            var result =  roleBUS.AddRole(rolename, roleinfo);
            if (result)
            {
                Hide() ;
                RoleWindow role = new RoleWindow();
                role.LoadRoles();
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

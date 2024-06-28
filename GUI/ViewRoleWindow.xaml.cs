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
    /// Interaction logic for ViewRoleWindow.xaml
    /// </summary>
    public partial class ViewRoleWindow : Window
    {
        private int _id;
        private readonly RoleBUS role = new RoleBUS();
        public ViewRoleWindow(int id)
        {
            InitializeComponent();
            _id = id;
            
            var data = role.GetRole(id);
            RoleNameTextBox.Text = data.RoleName;
            RoleInfoTextBox.Text = data.RoleInfo;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var rolename = RoleNameTextBox.Text;
            var roleinfo = RoleInfoTextBox.Text;
            var result = role.UpdateRole(_id, rolename, roleinfo);
            if (result)
            {
                Hide();
                RoleWindow roleWindow = new RoleWindow();
                roleWindow.LoadRoles();
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = role.DeleteRole(_id);
            if (result)
            {
                Hide();
                RoleWindow roleWindow = new RoleWindow();
                roleWindow.LoadRoles();
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

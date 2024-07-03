using Services;
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
    /// Interaction logic for EditMemberRoleView.xaml
    /// </summary>
    public partial class EditMemberRoleView : Window
    {
        private readonly Member_In_Project_Services member_In_Project = new Member_In_Project_Services();
        private readonly Role_Services role_Services = new Role_Services();
        private readonly int _memberID;
        private readonly int _projectID;
        public EditMemberRoleView(int projectID, int memberID)
        {
            _memberID = memberID;
            _projectID = projectID;
            InitializeComponent();
            var data = member_In_Project.GetMemberInProject(projectID, memberID);
            var load_data_role = role_Services.GetRoles();
            var array_data_role = new List<string>();
            foreach (var item in load_data_role)
            {
                array_data_role.Add(item.RoleName);
            }
            RoleComboBox.ItemsSource = array_data_role;
            RoleComboBox.SelectedItem = role_Services.GetRole(data.RoleID).RoleName;
        }

        private void UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            var new_role = RoleComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(new_role))
            {
                throw new Exception("Can be null here");
            }
            var roleid = role_Services.GetRoleByText(new_role);
            var result = member_In_Project.UpdateMemberInProject(_memberID,_projectID, roleid);
            if (result)
            {
                MessageBox.Show("Confirm", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Member delete false", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}

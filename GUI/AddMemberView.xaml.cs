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
    /// Interaction logic for AddMemberView.xaml
    /// </summary>
    public partial class AddMemberView : Window
    {
        private readonly Member_In_Project_Services member_In_Project_Services = new Member_In_Project_Services();
        private readonly Project_Services project_Services = new Project_Services();
        private readonly Role_Services role_Services = new Role_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly int _projectID;
        public AddMemberView(int projectID)
        {
            InitializeComponent();

            var data_user = user_Services.GetUsers();
            var array_user_id = new List<int>()
            {
                0
            };
            foreach (var user in data_user)
            {
                array_user_id.Add(user.UserID);
            }
            UserIDComboBox.ItemsSource = array_user_id;

            var data_role = role_Services.GetRoles();
            var array_role_name = new List<string>()
            {
                "Node"
            };
            foreach (var role in data_role)
            {
                array_role_name.Add(role.RoleName);
            }
            RoleNameComboBox.ItemsSource = array_role_name;

            _projectID = projectID;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var user_id = (int) UserIDComboBox.SelectedItem;
            
            var role_name = (string) RoleNameComboBox.SelectedItem;
            if (user_id == 0 ||role_name == "Node")
            {
                MessageBox.Show("");
            }
            else
            {
                
                var role_id = role_Services.GetRoleByText(role_name);
                var result = member_In_Project_Services.AddMemberToProject(user_id, _projectID, role_id);
                if (result)
                {
                    MessageBox.Show("Confirm", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    Hide();
                    ProjectMembersView projectMembersView = new ProjectMembersView(_projectID);
                    projectMembersView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Member add false", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}

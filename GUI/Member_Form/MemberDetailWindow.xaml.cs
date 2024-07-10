using Services._services;
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

namespace GUI.Member_Form
{
    /// <summary>
    /// Interaction logic for MemberDetailWindow.xaml
    /// </summary>
    public partial class MemberDetailWindow : Window
    {
        private readonly int _projectId;
        private readonly int _memberId;
        private readonly RoleServices roleServices = new RoleServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly UserServices userServices = new UserServices();
        public MemberDetailWindow(int memberId, int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            _memberId = memberId;
            LoadData();
            LoadRole();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var role_name = RoleComboBox.SelectedValue.ToString();
            if (role_name == "Node")
            {
                MessageBox.Show("Please select a role for this member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var role_id = roleServices.GetByName(role_name);
                var result = memberInProjectServices.UpdateMemberInProject(_memberId, role_id);
                if (result)
                {
                    MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Close();
                }
                else
                {
                    MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = memberInProjectServices.RemoveMemberFromProject(_memberId);
            if (result)
            {
                MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Warning);
                Close();
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoadData()
        {
            var data = memberInProjectServices.GetMemberInProject(_memberId);
            ProjectNameTextBlock.Text = projectServices.GetProject(_projectId).ProjectName;
            MemberNameTextBlock.Text = userServices.GetUser(data.UserID).UserName;
            RoleComboBox.SelectedValue = roleServices.GetRole(data.RoleID).RoleName;
        }
        private void LoadRole()
        {
            var data = roleServices.GetRoles();
            var array_data_role = new List<string>()
            {
                "Node"
            };
            foreach (var role in data)
            {
                array_data_role.Add(role.RoleName);
            }
            RoleComboBox.ItemsSource = array_data_role;
        }
    }
}

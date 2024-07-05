using Models;
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
    /// Interaction logic for ProjectMembersView.xaml
    /// </summary>
    public partial class ProjectMembersView : Window
    {
        private readonly int _projectID;
        private readonly Member_In_Project_Services member_In_Project = new Member_In_Project_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly Role_Services role_Services = new Role_Services();
        public ProjectMembersView(int projectID)
        {
            InitializeComponent();
            _projectID = projectID;
            var data = member_In_Project.GetMembersInProject(projectID)
                .Select(x => new MemberResponse()
                {
                    MemberID = x.MemberID,
                    
                    UserName = user_Services.GetUser(x.UserID).UserName,
                    RoleName = role_Services.GetRole(x.RoleID).RoleName,
                });
            
            MembersDataGrid.ItemsSource = data;
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            AddMemberView addMemberView = new AddMemberView(_projectID);
            addMemberView.Show();
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if(MembersDataGrid.SelectedItem is MemberResponse member_selected)
            {
                var result = member_In_Project.DeleteMemberFromProject(member_selected.MemberID, _projectID);
                if (result)
                {
                    MessageBox.Show("Confirm", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Member delete false", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AdjustRole_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem is MemberResponse member_selected)
            {
                EditMemberRoleView editMemberRoleView = new EditMemberRoleView(_projectID, member_selected.MemberID);
                editMemberRoleView.Show();
            }
            else
            {
                MessageBox.Show("");
            }
                
        }
    }
}

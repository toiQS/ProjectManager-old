using Models;
using Services;
using System;
using System.Linq;
using System.Windows;

namespace GUI
{
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
            LoadMembersData();
        }

        private void LoadMembersData()
        {
            try
            {
                var data = member_In_Project.GetMembersInProject(_projectID)
                    .Select(x => new MemberResponse()
                    {
                        MemberID = x.MemberID,
                        UserName = user_Services.GetUser(x.UserID)?.UserName ?? "Unknown",
                        RoleName = role_Services.GetRole(x.RoleID)?.RoleName ?? "Unknown",
                    }).ToList();

                MembersDataGrid.ItemsSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading project members: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddMemberView>(() => new AddMemberView(_projectID));
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem is MemberResponse member_selected)
            {
                var result = member_In_Project.DeleteMemberFromProject(member_selected.MemberID, _projectID);
                if (result)
                {
                    MessageBox.Show("Member deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadMembersData();
                }
                else
                {
                    MessageBox.Show("Failed to delete member.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.", "No Member Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AdjustRole_Click(object sender, RoutedEventArgs e)
        {
            if (MembersDataGrid.SelectedItem is MemberResponse member_selected)
            {
                ShowWindow<EditMemberRoleView>(() => new EditMemberRoleView(_projectID, member_selected.MemberID));
            }
            else
            {
                MessageBox.Show("Please select a member to adjust role.", "No Member Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        // Generic method to show a window
        private void ShowWindow<T>(Func<T> windowConstructor) where T : Window
        {
            try
            {
                var newWindow = windowConstructor.Invoke();
                newWindow.Owner = this;
                newWindow.Closed += (s, args) => ShowMainWindow();
                Hide();
                newWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowMainWindow()
        {
            Show();
        }
    }
}

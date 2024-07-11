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

        /// <summary>
        /// Initializes a new instance of the MemberDetailWindow class.
        /// </summary>
        /// <param name="memberId">The ID of the member to be managed.</param>
        /// <param name="projectId">The ID of the project the member is associated with.</param>
        public MemberDetailWindow(int memberId, int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            _memberId = memberId;
            LoadData();
            LoadRole();
        }

        /// <summary>
        /// Handles the Click event of the SaveButton.
        /// Updates the role of the member in the project.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var role_name = RoleComboBox.SelectedValue.ToString();

            // Validate if a role is selected
            if (role_name == "Node")
            {
                MessageBox.Show("Please select a role for this member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var role_id = roleServices.GetByName(role_name);
                var result = memberInProjectServices.UpdateMemberInProject(_memberId, role_id);

                // Show appropriate message based on the result
                if (result)
                {
                    MessageBox.Show("Confirm", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error updating member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteButton.
        /// Removes the member from the project.
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = memberInProjectServices.RemoveMemberFromProject(_memberId);

            // Show appropriate message based on the result
            if (result)
            {
                MessageBox.Show("Confirm", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error removing member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Handles the Click event of the BackButton.
        /// Closes the current window.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the member's data into the UI elements.
        /// </summary>
        private void LoadData()
        {
            var data = memberInProjectServices.GetMemberInProject(_memberId);
            ProjectNameTextBlock.Text = projectServices.GetProject(_projectId).ProjectName;
            MemberNameTextBlock.Text = userServices.GetUser(data.UserID).UserName;
            RoleComboBox.SelectedValue = roleServices.GetRole(data.RoleID).RoleName;
        }

        /// <summary>
        /// Loads the available roles into the RoleComboBox.
        /// </summary>
        private void LoadRole()
        {
            var data = roleServices.GetRoles();
            var array_data_role = new List<string> { "Node" };

            foreach (var role in data)
            {
                array_data_role.Add(role.RoleName);
            }

            RoleComboBox.ItemsSource = array_data_role;
        }
    }
}

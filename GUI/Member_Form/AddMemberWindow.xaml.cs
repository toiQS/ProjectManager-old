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
    /// Interaction logic for AddMemberWindow.xaml
    /// </summary>
    public partial class AddMemberWindow : Window
    {
        private readonly RoleServices roleServices = new RoleServices();
        private readonly UserServices userServices = new UserServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();
        private readonly int _projectId;

        /// <summary>
        /// Initializes a new instance of the AddMemberWindow class.
        /// </summary>
        /// <param name="projectId">The ID of the project to add a member to.</param>
        public AddMemberWindow(int projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            LoadRole();
        }

        /// <summary>
        /// Handles the Click event of the SaveButton.
        /// Saves the new member to the project with the provided details.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var user_id = Convert.ToInt32(MemberIdTextBox.Text);
            var role_name = RoleComboBox.SelectedValue.ToString();

            // Validate input fields
            if (user_id < 1 || role_name == "Node")
            {
                MessageBox.Show("Please fill in all information", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var role_id = roleServices.GetByName(role_name);
                var result = memberInProjectServices.AddMemberToProject(_projectId, role_id, user_id);

                // Show appropriate message based on the result
                if (result)
                {
                    MessageBox.Show("Confirm", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Error adding member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton.
        /// Closes the current window without saving.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the role options into the RoleComboBox.
        /// </summary>
        private void LoadRole()
        {
            var data = roleServices.GetRoles();
            var array_role_name = new List<string> { "Node" };

            foreach (var role in data)
            {
                array_role_name.Add(role.RoleName);
            }

            RoleComboBox.ItemsSource = array_role_name;
        }
    }
}

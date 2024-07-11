using Models;
using Services._services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        private readonly int _userId;
        private readonly int _projectId;
        private readonly UserServices userServices = new UserServices();
        private readonly RoleServices roleServices = new RoleServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();
        private readonly ProjectServices projectServices = new ProjectServices();

        /// <summary>
        /// Initializes a new instance of the MemberWindow class.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="userId">The ID of the user.</param>
        public MemberWindow(int projectId, int userId)
        {
            InitializeComponent();
            _userId = userId;
            _projectId = projectId;
            LoadData();
            var isMember = memberInProjectServices.GetMemberInProject(_userId, _projectId) ?? null;

            // Check if the user is a member and if the user is not the project creator or not a role ID of 1 (admin role).
            if (isMember != null)
            {
                var person_create_id = projectServices.GetProject(_projectId).UserID;
                if (isMember.RoleID != 1 || _userId != person_create_id)
                {
                    AddButton.Visibility = Visibility.Hidden;
                    ViewButton.Visibility = Visibility.Hidden;
                }
            }
            
        }

        /// <summary>
        /// Handles the Click event of the AddButton.
        /// Opens the AddMemberWindow.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddMemberWindow>(() => new AddMemberWindow(_projectId));
        }

        /// <summary>
        /// Handles the Click event of the ViewButton.
        /// Opens the MemberDetailWindow for the selected member.
        /// </summary>
        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (MemberListView.SelectedItem is Member_In_Project_Response member_selected)
            {
                ShowWindow<MemberDetailWindow>(() => new MemberDetailWindow(member_selected.MemberID, _projectId));
            }
            else
            {
                MessageBox.Show("Please choose a member", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
        /// Loads the members data into the MemberListView.
        /// </summary>
        private void LoadData()
        {
            var data = memberInProjectServices.GetMembersByProjectId(_projectId)
                .Select(x => new Member_In_Project_Response()
                {
                    MemberID = x.MemberID,
                    MemberName = userServices.GetUser(x.UserID).UserName,
                    MemberRole = roleServices.GetRole(x.RoleID).RoleName
                });
            if (data != null)
            {
                MemberListView.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("Can't get data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens a new window and hides the current one.
        /// </summary>
        /// <typeparam name="T">The type of the window to be opened.</typeparam>
        /// <param name="windowConstructor">The constructor function for the new window.</param>
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

        /// <summary>
        /// Shows the main window.
        /// </summary>
        private void ShowMainWindow()
        {
            Show();
        }
    }
}

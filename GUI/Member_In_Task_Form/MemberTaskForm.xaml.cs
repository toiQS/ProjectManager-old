﻿using Models;
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

namespace GUI.Member_In_Task_Form
{
    /// <summary>
    /// Interaction logic for MemberTaskForm.xaml
    /// </summary>
    public partial class MemberTaskForm : Window
    {
        private readonly int _taskId;
        private readonly int _userId;
        private readonly MemberInTaskServices memberInTaskServices = new MemberInTaskServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();
        private readonly UserServices userServices = new UserServices();
        private readonly ProjectServices projectServices = new ProjectServices();

        /// <summary>
        /// Initializes a new instance of the MemberTaskForm class.
        /// </summary>
        /// <param name="taskId">The ID of the task.</param>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="userId">The ID of the user.</param>
        public MemberTaskForm(int taskId, int projectId, int userId)
        {
            InitializeComponent();
            _taskId = taskId;
            _userId = userId;
            LoadData();
            var user_root = projectServices.GetProject(projectId).UserID;
            var isMember = memberInProjectServices.GetUserInProject(userId, projectId);
            int role_id;
            if (isMember == null)
            {
                role_id = 0;
            }
            else
            {
                role_id = isMember.RoleID;
            }
            if (role_id == 1 || userId == user_root)
            {
                AddMemberButton.Visibility = Visibility.Visible;

            }
            else
            {
                AddMemberButton.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Handles the Click event of the AddMemberButton.
        /// Opens the form to add a member to the task.
        /// </summary>
        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddMemberView>(() => new AddMemberView(_taskId, _userId));
        }

        /// <summary>
        /// Handles the Click event of the DeleteMemberButton.
        /// Opens the form to delete a member from the task.
        /// </summary>
        private void DeleteMemberButton_Click(object sender, RoutedEventArgs e)
        {
            // Add logic for deleting a member from the task.
            if (MemberListView.SelectedItems is Member_In_Task_Response member_selected)
            {
                var result = memberInTaskServices.RemoveMemberFromTask(member_selected.Member_In_Task_ID);
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
            var data = memberInTaskServices.GetMembersByTaskId(_taskId)
                .Select(x => new Member_In_Task_Response()
                {
                    Member_In_Task_ID = x.Member_In_Task_ID,
                    MemberID = x.MemberID,
                    UserName = userServices.GetUser(memberInProjectServices.GetMemberInProject(x.MemberID).UserID).UserName
                });

            // Check if data is not null and set it as the ItemsSource for MemberListView.
            if (data != null)
            {
                MemberListView.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("Can't load data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Opens a new window of type T and hides the current window.
        /// Shows the main window again when the new window is closed.
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

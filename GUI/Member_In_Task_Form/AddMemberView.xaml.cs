using Services._services;
using System;
using System.Windows;

namespace GUI.Member_In_Task_Form
{
    /// <summary>
    /// Interaction logic for AddMemberView.xaml
    /// </summary>
    public partial class AddMemberView : Window
    {
        private readonly int _taskId;
        private readonly int _projectId;
        private readonly MemberInTaskServices memberInTaskServices = new MemberInTaskServices();
        private readonly TaskInProjectServices taskInProjectServices = new TaskInProjectServices();
        private readonly MemberInProjectServices memberInProjectServices = new MemberInProjectServices();

        /// <summary>
        /// Initializes a new instance of the AddMemberView class.
        /// </summary>
        /// <param name="taskId">The ID of the task to which a member is being added.</param>
        /// <param name="projectId">The ID of the project associated with the task.</param>
        public AddMemberView(int taskId, int projectId)
        {
            InitializeComponent();
            TaskNameTextBlock.Text = taskInProjectServices.GetTask(taskId).TaskName;
            _taskId = taskId;
            _projectId = projectId;
        }

        /// <summary>
        /// Handles the Click event of the AddButton.
        /// Attempts to add a member to the task.
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(MemberIDTextBox.Text))
            {
                MessageBox.Show("Please fill member id", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                try
                {
                    var new_member_id = Convert.ToInt32(MemberIDTextBox.Text);
                    var get_project_id = memberInProjectServices.GetMemberInProject(new_member_id).ProjectID;
                    if (get_project_id == _projectId)
                    {
                        var result = memberInTaskServices.AddMemberToTask(_taskId, new_member_id);
                        // Show appropriate message based on the result
                        if (result)
                        {
                            MessageBox.Show("Member added to task successfully", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            Close(); // Close the window after successful addition
                        }
                        else
                        {
                            MessageBox.Show("Error adding member to task", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Member does not belong to the project", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid member ID format", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the CancelButton.
        /// Closes the current window.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

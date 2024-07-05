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
    /// Interaction logic for ProjectDetailView.xaml
    /// </summary>
    public partial class ProjectDetailView : Window
    {
        private readonly int _projectId;
        private readonly Project_Services project_Services = new Project_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly Status_Services status_Services = new Status_Services();
        public ProjectDetailView(int projectId)
        {
            InitializeComponent();
            
            var data = project_Services.GetProject(projectId);
            var convert_data = new ProjectResponseDetail()
            {
                ProjectID = data.ProjectID,
                ProjectName = data.ProjectName,
                CreateAt = data.CreateAt,
                EndAt = data.EndAt,
                Quantity_Member_Requied = data.Quantity_Member_Requied,
                PersonalCreated = user_Services.GetUser(data.UserID).UserName,
                ProjectDescription = data.ProjectDescription,
                ProjectInfo = data.ProjectInfo,
                StartAt = data.StartAt,
                Status = status_Services.GetStatus(data.StatusID).StatusName,
            }; 
            ProjectNameTextBox.Text = convert_data.ProjectName;
            StartDatePicker.SelectedDate = convert_data.StartAt;
            EndDatePicker.SelectedDate = convert_data.EndAt;
            InfoTextBox.Text = convert_data.ProjectInfo;
            DescriptionTextBox.Text = convert_data.ProjectDescription;
            CreationDatePicker.SelectedDate = convert_data.CreateAt;
            CreatorTextBox.Text = convert_data.PersonalCreated;
            //StatusComboBox.ItemsSource = status_Services.GetStatuses();
            //StatusComboBox.SelectedItem = StatusComboBox.Items.Cast<Status>()
            //    .FirstOrDefault(s => s.StatusName == convert_data.Status);
            var load_data_status = status_Services.GetStatuses();
            var array_data_status = new List<string>();
            foreach (var item in load_data_status)
            {
                array_data_status.Add(item.StatusName);
            }
            StatusComboBox.ItemsSource = array_data_status;
            StatusComboBox.SelectedItem = array_data_status
                 .FirstOrDefault(status => status == convert_data.Status);
            MemberCountTextBox.Text = Convert.ToString(convert_data.Quantity_Member_Requied);
            _projectId = convert_data.ProjectID;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectWindow projectWindow = new ProjectWindow();
            projectWindow.Show();
        }


        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            EditProjectView projectView = new EditProjectView(_projectId);
            projectView.Show();
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            var result = project_Services.DeleteProject(_projectId);
            if (result)
            {
                MessageBox.Show("Confirm", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Project delete false", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ManageProgress_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ManageTasksView projectView = new ManageTasksView(_projectId);
            projectView.Show();
        }

        private void ManageMembers_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectMembersView projectMembersView = new ProjectMembersView(_projectId);
            projectMembersView.Show();
        }
    }
}

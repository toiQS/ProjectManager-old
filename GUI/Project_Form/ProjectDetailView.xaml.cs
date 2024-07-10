using GUI.Member_Form;
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

namespace GUI.Project_Form
{
    /// <summary>
    /// Interaction logic for ProjectDetailView.xaml
    /// </summary>
    public partial class ProjectDetailView : Window
    {
        private readonly int _userId;
        private readonly int _projectId;
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly StatusServices statusServices = new StatusServices();
        private readonly UserServices userServices = new UserServices();
        public ProjectDetailView(int projectId, int userId)
        {
            InitializeComponent();
            _userId = userId;
            _projectId = projectId;
            var user_root = LoadData();
            if (userId != user_root)
            {
                UpdateButton.Visibility = Visibility.Hidden;
                UpdateButton.IsEnabled = false;
            }
            else
            {
                UpdateButton.IsEnabled = true;
            }
        }
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

        private int LoadData()
        {
            var data = projectServices.GetProject(_projectId);
            ProjectNameLabel.Text = data.ProjectName;
            ProjectInfoLabel.Text = data.ProjectInfo;
            DescriptionLabel.Text = data.ProjectDescription;
            StartDateLabel.Text = data.StartAt.ToString();
            EndDateLabel.Text = data.EndAt.ToString();
            CreatedDateLabel.Text = data.CreateAt.ToString();
            StatusLabel.Text = statusServices.GetStatus(data.StatusID).StatusName;
            CreatedDateLabel.Text = userServices.GetUser(data.UserID).UserName;
            return data.UserID;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ManageTasksButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ManageMembersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<MemberWindow>(() => new MemberWindow(_projectId, _userId));
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<UpdateProjectView>(() => new UpdateProjectView(_projectId));
        }
    }
}

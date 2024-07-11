using Models;
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private readonly int _userID;
        private readonly ProjectServices projectServices = new ProjectServices();
        private readonly StatusServices statusServices = new StatusServices();
        private readonly UserServices userServices = new UserServices();
        public ProjectWindow(int userId)
        {
            InitializeComponent();
            LoadData();
            _userID = userId;
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse project_selected)
            {
                ShowWindow<ProjectDetailView>(() => new ProjectDetailView(project_selected.ProjectID, _userID));
            }
            else
            {
                MessageBox.Show("Please choise a item","Warning",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow<AddProjectWindow>(() => new AddProjectWindow(_userID));
        }

        private void EditButton_Click(object sender, object e)
        {
            if (ProjectListView.SelectedItem is ProjectResponse project_selected)
            {
                ShowWindow<ProjectDetailView>(() => new ProjectDetailView(project_selected.ProjectID,_userID));
            }
            else
            {
                MessageBox.Show("Please choise a project","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoadData()
        {
            var data = projectServices.GetProjects()
                .Select(x => new ProjectResponse()
                {
                    EndAt = x.EndAt,
                    PersonalCreated = userServices.GetUser(x.UserID).UserName,
                    ProjectID = x.ProjectID,
                    ProjectName = x.ProjectName,
                    ProjectDescription = x.ProjectDescription,
                    StartAt = x.StartAt,
                    Status = statusServices.GetStatus(x.UserID).StatusName,
                });
            if(data == null)
            {
                MessageBox.Show("Can't get data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            ProjectListView.ItemsSource = data; 
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
    }
}

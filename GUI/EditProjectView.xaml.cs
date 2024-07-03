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
    /// Interaction logic for EditProjectView.xaml
    /// </summary>
    public partial class EditProjectView : Window
    {
        private readonly int _projectId;
        private readonly Project_Services project_Services = new Project_Services();
        private readonly User_Services user_Services = new User_Services();
        private readonly Status_Services status_Services = new Status_Services();
        public EditProjectView(int projectID)
        {
            InitializeComponent();
            _projectId = projectID;
            if (_projectId == 0) throw new Exception("Can be null here");
            var data = project_Services.GetProject(id: _projectId);
            var convert_data = new ProjectResponseDetail()
            {
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
            txtProjectName.Text = convert_data.ProjectName;
            txtProjectInfo.Text = convert_data.ProjectInfo;
            txtProjectDescription.Text = convert_data.ProjectDescription;
            txtMember.Text = convert_data.Quantity_Member_Requied.ToString();
            dpStartAt.SelectedDate = convert_data.StartAt;
            dpEndAt.SelectedDate = convert_data.EndAt;
            var load_data_status = status_Services.GetStatuses();
            var array_data_status = new List<string>();
            foreach (var item in load_data_status)
            {
                array_data_status.Add(item.StatusName);
            }
            cbStatus.ItemsSource = array_data_status;
            cbStatus.SelectedItem = array_data_status
                 .FirstOrDefault(status => status == convert_data.Status);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var project_name = txtProjectName.Text;
            var project_description = txtProjectDescription.Text;
            var project_info = txtProjectInfo.Text;
            var start_at = dpStartAt.SelectedDate.Value;
            var end_at = dpEndAt.SelectedDate.Value;
            var quantity_member = Convert.ToInt32(txtMember.Text);
            var status_selected = cbStatus.SelectedItem.ToString();
            if (string.IsNullOrEmpty(status_selected))
            {
                throw new Exception(status_selected);
            }

            var status_id = status_Services.GetIdByText(status_selected);
            var result = project_Services.UpdateProject(_projectId, project_name, project_info, project_description, start_at, end_at, quantity_member, status_id);
            if (result)
            {
                MessageBox.Show("Confirm","Message",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Project update false","Message",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}

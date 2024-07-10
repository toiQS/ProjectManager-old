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
        
        public MemberWindow(int projectId, int userId)
        {
            InitializeComponent();
            _userId = userId;
            _projectId = projectId;
            LoadData();
            var isMember = memberInProjectServices.GetMemberInProject(_userId, _projectId) ?? null;
            if (isMember != null)
            {
                var person_create_id = projectServices.GetProject(_projectId).UserID;
                if(isMember.RoleID != 1 || _userId != person_create_id)
                {
                    AddButton.Visibility = Visibility.Hidden;
                    ViewButton.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                Close();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
                
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoadData()
        {
            var data = memberInProjectServices.GetMembersByProjectId(_projectId)
                .Select(x => new Member_In_Project_Response()
                {
                    MemberID = x.MemberID,
                    MemberName = userServices.GetUser(x.UserID).UserName,
                    MemberRole = roleServices.GetRole(x.RoleID).RoleName
                });
            if(data != null)
            {
                MemberListView.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("Can't get data","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

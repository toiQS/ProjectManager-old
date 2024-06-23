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
    /// Interaction logic for ProjectMembersView.xaml
    /// </summary>
    public partial class ProjectMembersView : Window
    {
        public ProjectMembersView()
        {
            InitializeComponent();
        }

        private void AddMember_Click(object sender, RoutedEventArgs e)
        {
            AddMemberView addMemberView = new AddMemberView();
            addMemberView.Show();
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdjustRole_Click(object sender, RoutedEventArgs e)
        {
            EditMemberRoleView editMemberRoleView = new EditMemberRoleView();   
            editMemberRoleView.Show();
        }
    }
}

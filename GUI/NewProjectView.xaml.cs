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
    /// Interaction logic for NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : Window
    {
        public NewProjectView()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectDetailView projectDetailView = new ProjectDetailView();
            projectDetailView.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ProjectWindow projectWindow = new ProjectWindow();
            projectWindow.Show();
        }
    }
}

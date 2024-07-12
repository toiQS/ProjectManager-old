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

namespace GUI.Option_Form
{
    /// <summary>
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        private readonly int _userId;
        public OptionWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void ManageTaskLevels_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageRoles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ManageStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

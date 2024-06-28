using BUS._role;
using BUS._status;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddStatusWindow.xaml
    /// </summary>
    public partial class AddStatusWindow : Window
    {
        
        public AddStatusWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AddStatusButton_Click(object sender, RoutedEventArgs e)
        {
            string status_name = StatusNameTextBox.Text;
            string status_info = StatusInfoTextBox.Text;
            if (string.IsNullOrEmpty(status_name) || string.IsNullOrEmpty(status_info))
            {
                MessageBox.Show("Please input data", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            StatusBUS statusBUS = new StatusBUS();
            var result = statusBUS.AddStatus(status_name, status_info);
            if (result)
            {
                Hide();
                MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("False","Warning",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Interaction logic for ViewStatusWindow.xaml
    /// </summary>
    public partial class ViewStatusWindow : Window
    {
        private readonly int _id;
        public ViewStatusWindow(int id)
        {
            InitializeComponent();
            _id = id;
            StatusBUS statusBUS = new StatusBUS();
            var data = statusBUS.GetStatus(_id);
            StatusNameTextBox.Text = data.StatusName;
            StatusInfoTextBox.Text = data.StatusInfo;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StatusBUS statusBUS = new StatusBUS();
            string status_name = StatusNameTextBox.Text;
            string status_info = StatusInfoTextBox.Text;
            var result = statusBUS.UpdateStatus(_id, status_name, status_info);
            if (result)
            {
                Hide();
                MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            StatusBUS statusBUS = new StatusBUS();
            var result = statusBUS.DeleteStatus(_id);
            if (result)
            {
                Hide();
                MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

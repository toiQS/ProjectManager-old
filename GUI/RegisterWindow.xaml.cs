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

namespace GUI
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly UserServices userServices = new UserServices();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var user_name = UserNameTextBox.Text;
            var password = PasswordBox.Password;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email, User Name or Password war null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                var check_data = userServices.Login(email, password);
                if (check_data)
                {
                    MessageBox.Show("An account was exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    var result = userServices.AddUser(user_name, email, password);
                    if (result)
                    {
                        MessageBox.Show("Comfirm", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("False", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}

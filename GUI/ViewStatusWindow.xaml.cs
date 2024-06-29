using System.Windows;

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
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

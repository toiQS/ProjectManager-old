﻿using BUS._status;
using DTO;
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
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        private readonly StatusBUS statusBUS;
        public StatusWindow()
        {
            InitializeComponent();
            statusBUS = new StatusBUS();
            StatusListView.ItemsSource = statusBUS.GetStatuses();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddStatusWindow addStatusWindow = new AddStatusWindow();
            addStatusWindow.ShowDialog();
        }

        private void ViewEditButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusListView.SelectedItem is Status statusSelected)
            {
                int id = statusSelected.StatusID;
                ViewStatusWindow viewStatusWindow = new ViewStatusWindow(id);
                viewStatusWindow.ShowDialog();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}

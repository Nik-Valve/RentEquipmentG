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

namespace RentEquipmentGupalo.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStaffWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.StaffWindow staffWindow = new Windows.StaffWindow();
            this.Hide();
            staffWindow.ShowDialog();
            this.Show();
        }

        private void btnEquipListWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.EquipListWindow equipListWindow = new Windows.EquipListWindow();
            this.Hide();
            equipListWindow.ShowDialog();
            this.Show();
        }

        private void btnEquipExtWindow_Click(object sender, RoutedEventArgs e)
        {
            Windows.EquipExtWindow equipExtWindow = new Windows.EquipExtWindow();
            this.Hide();
            equipExtWindow.ShowDialog();
            this.Show();
        }

        private void btnClientList_Click(object sender, RoutedEventArgs e)
        {
            Windows.ClientListWindow clientListWindow = new Windows.ClientListWindow();
            this.Hide();
            clientListWindow.ShowDialog();
            this.Show();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

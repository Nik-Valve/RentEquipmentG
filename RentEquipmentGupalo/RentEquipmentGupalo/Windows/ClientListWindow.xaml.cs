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
    /// Логика взаимодействия для ClientListWindow.xaml
    /// </summary>
    public partial class ClientListWindow : Window
    {
        List<string> ListSort = new List<string>()
    {
        "По умолчанию","По фамилии","По имени","По телефону","По почте","По должности"
    };
        public ClientListWindow()
        {
            InitializeComponent();
            Filter();
            lvStaff.ItemsSource = ClassHelper.AppData.Context.Staff.ToList();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;

        }

        //добавление

        private void btnStaffAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientListWindow staffAddWindow = new AddClientListWindow();
            staffAddWindow.ShowDialog();
            lvStaff.ItemsSource = ClassHelper.AppData.Context.Client.ToList();
            Filter();
        }

        private void Filter()
        {
            List<EF.Client> ListStaff = new List<EF.Client>();
            ListStaff = ClassHelper.AppData.Context.Client.Where(i => i.IsDeleted == false).ToList();
            //Фильтрация
            ListStaff = ListStaff.Where(i =>
            i.LastName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FirstName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.MiddleName.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.FIO.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Phone.ToLower().Contains(txtSearch.Text.ToLower()) ||
            i.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListStaff = ListStaff.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    ListStaff = ListStaff.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    ListStaff = ListStaff.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    ListStaff = ListStaff.OrderBy(i => i.Phone).ToList();
                    break;
                case 4:
                    ListStaff = ListStaff.OrderBy(i => i.Email).ToList();
                    break;
                default:
                    ListStaff = ListStaff.OrderBy(i => i.ID).ToList();
                    break;
            }
            lvStaff.ItemsSource = ListStaff;
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        //Удаление

        private void lvStaff_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvStaff.SelectedItem is EF.Client)
                    {
                        var resmsg = MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvStaff.SelectedItem as EF.Client;
                        stf.IsDeleted = true;
                        //ClassHelper.AppData.Context.Staff.Remove(stf);
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Пользователь успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lvStaff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvStaff.SelectedItem is EF.Client)
            {
                var stf = lvStaff.SelectedItem as EF.Client;
                var stf1 = lvStaff.SelectedItem as EF.Passport;
                AddClientListWindow staffAddWindow = new AddClientListWindow(stf,stf1);
                staffAddWindow.ShowDialog();
                Filter();

            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

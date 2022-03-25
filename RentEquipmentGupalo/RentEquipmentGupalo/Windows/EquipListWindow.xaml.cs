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
    /// Логика взаимодействия для EquipListWindow.xaml
    /// </summary>
    public partial class EquipListWindow : Window
    {
            List<string> ListSort = new List<string>()
    {
        "По умолчанию","По имени","По ID"
    };
            public EquipListWindow()
        {
            InitializeComponent();
            Filter();
            lvEquipList.ItemsSource = ClassHelper.AppData.Context.Product.ToList();
            cmbSort.ItemsSource = ListSort;
            cmbSort.SelectedIndex = 0;
        }
        private void Filter()
        {
            List<EF.Product> listEquip = new List<EF.Product>();
            listEquip = ClassHelper.AppData.Context.Product.Where(i => i.IsDeleted == false).ToList();
            
            //Фильтрация
            listEquip = listEquip.Where(i =>
            i.NameProduct.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    listEquip = listEquip.OrderBy(i => i.NameProduct).ToList();
                    break;
                default:
                    listEquip = listEquip.OrderBy(i => i.ID).ToList();
                    break;
            }
            lvEquipList.ItemsSource = listEquip;
        }

        private void lvEquipList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvEquipList.SelectedItem is EF.Product)
                    {
                        var resmsg = MessageBox.Show("Удалить оборудование?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvEquipList.SelectedItem as EF.Product;
                        //ClassHelper.AppData.Context.Product.Remove(stf);
                        stf.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Оборудование успешно удалено", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lvEquipList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvEquipList.SelectedItem is EF.Product)
            {
                var stf = lvEquipList.SelectedItem as EF.Product;
                AddEquipListWindow addEquipListWindow = new AddEquipListWindow(stf);
                addEquipListWindow.ShowDialog();
                Filter();

            }
        }

        private void lvEquipList_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvEquipList.SelectedItem is EF.Product)
                    {
                        var resmsg = MessageBox.Show("Удалить продукт?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvEquipList.SelectedItem as EF.Product;
                        stf.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Продукт успешно удален", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnStaffAdd_Click(object sender, RoutedEventArgs e)
        {
            
            AddEquipListWindow staffAddWindow = new AddEquipListWindow();
            staffAddWindow.ShowDialog();
            lvEquipList.ItemsSource = ClassHelper.AppData.Context.Product.ToList();
            Filter();
        }
    }
}


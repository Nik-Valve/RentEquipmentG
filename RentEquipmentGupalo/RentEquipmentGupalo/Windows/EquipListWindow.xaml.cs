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
        public EquipListWindow()
        {
            InitializeComponent();
            lvEquipList.ItemsSource = ClassHelper.AppData.Context.Product.ToList();
        }
        private void Filter()
        {
            List<EF.Product> listEquip = new List<EF.Product>();
            listEquip = ClassHelper.AppData.Context.Product.Where(i => i.IsDeleted == false).ToList();
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
    }
}


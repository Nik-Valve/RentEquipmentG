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
    /// Логика взаимодействия для EquipExtWindow.xaml
    /// </summary>
    public partial class EquipExtWindow : Window
    {
        public EquipExtWindow()
        {
            InitializeComponent();
            lvEquipExt.ItemsSource = ClassHelper.AppData.Context.ClientProduct.ToList();
        }
        private void Filter()
        {
            List<EF.ClientProduct> ListClientProduct = new List<EF.ClientProduct>();
            ListClientProduct = ClassHelper.AppData.Context.ClientProduct.Where(i => i.IsDeleted == false).ToList();
            lvEquipExt.ItemsSource = ListClientProduct;
        }

        private void lvEquipExt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvEquipExt.SelectedItem is EF.ClientProduct)
                    {
                        var resmsg = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvEquipExt.SelectedItem as EF.ClientProduct;
                        stf.IsDeleted = true;
                        ClassHelper.AppData.Context.SaveChanges();
                        MessageBox.Show("Запись успешно удалена", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Filter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnEExtWindow_Click(object sender, RoutedEventArgs e)
        {
            EquipExtAddWindow equipExtAddWindow = new EquipExtAddWindow();
            equipExtAddWindow.ShowDialog();
            this.Show();
            Filter();
        }
    }
}

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
        public ClientListWindow()
        {
            InitializeComponent();
            lvClientList.ItemsSource = ClassHelper.AppData.Context.Client.ToList();
        }
        private void Filter()
        {
            List<EF.Client> ListClient = new List<EF.Client>();
            ListClient = ClassHelper.AppData.Context.Client.Where(i => i.IsDeleted == false).ToList();
            lvClientList.ItemsSource = ListClient;
        }

        private void lvClientList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                try
                {
                    if (lvClientList.SelectedItem is EF.Client)
                    {
                        var resmsg = MessageBox.Show("Удалить пользователя?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resmsg == MessageBoxResult.No)
                        {
                            return;
                        }
                        var stf = lvClientList.SelectedItem as EF.Client;
                        //ClassHelper.AppData.Context.Client.Remove(stf);
                        stf.IsDeleted = true;
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
    }
}

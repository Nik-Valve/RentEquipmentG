using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEquipListWindow.xaml
    /// </summary>
    public partial class AddEquipListWindow : Window
    {
        private bool IsEdit = false;
        EF.Product editStaff = new EF.Product();
        string photostrl;
        public AddEquipListWindow()
        {
            InitializeComponent();
            cmbType.ItemsSource = ClassHelper.AppData.Context.Type.ToList();
            cmbType.DisplayMemberPath = "NameType";
            cmbType.SelectedItem = "0";
            cmbStatus.ItemsSource = ClassHelper.AppData.Context.Status.ToList();
            cmbStatus.DisplayMemberPath = "StatusName";
            cmbType.SelectedItem = "0";
            IsEdit = false;
        }
        public AddEquipListWindow(EF.Product staff)
        {
            InitializeComponent();
            IsEdit = true;
            cmbType.ItemsSource = ClassHelper.AppData.Context.Type.ToList();
            cmbType.DisplayMemberPath = "NameType";
            cmbStatus.ItemsSource = ClassHelper.AppData.Context.Status.ToList();
            cmbStatus.DisplayMemberPath = "StatusName";
            tbTitle.Text = "Изменение сотрудника";
            btnAdd.Content = "Изменить";
            txtName.Text = staff.NameProduct;
            txtPrice.Text = Convert.ToString(staff.Price);
            txtWarranty.Text = Convert.ToString(staff.Warranty);
            cmbType.SelectedIndex = staff.IDType - 1;
            cmbStatus.SelectedIndex = staff.IDStatus - 1;
            txtDeleted.Text = Convert.ToString(staff.IsDeleted);
            editStaff = staff;
            if (staff.Photo != null)
            {
                using (MemoryStream stream = new MemoryStream(staff.Photo))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    PhotoUser.Source = bitmapImage;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //валидация
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Поле Наименование не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Поле Стоимость не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtWarranty.Text))
            {
                MessageBox.Show("Поле Гарантия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //код
            var authUser = ClassHelper.AppData.Context.Product.ToList().
            Where(i => i.NameProduct == txtName.Text).FirstOrDefault();
            if (authUser != null && IsEdit == false)
            {
                MessageBox.Show("Данный логин занят!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            if (IsEdit == true)
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    editStaff.NameProduct = txtName.Text;
                    editStaff.IDType= (cmbType.SelectedItem as EF.Type).ID;
                    editStaff.Price = Convert.ToDecimal(txtPrice.Text);
                    editStaff.Warranty = Convert.ToDateTime(txtWarranty.Text);
                    editStaff.IDStatus = (cmbStatus.SelectedItem as EF.Status).ID;
                    editStaff.IsDeleted = Convert.ToBoolean(txtDeleted.Text);
                    if (photostrl != null)
                    {
                        editStaff.Photo = File.ReadAllBytes(photostrl);
                    }
                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Пользователь изменен");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                var resClick = MessageBox.Show("Вы уверены?", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resClick == MessageBoxResult.No)
                {
                    return;
                }
                try
                {
                    EF.Product newstaff = new EF.Product();
                    newstaff.NameProduct = txtName.Text;
                    newstaff.IDType = (cmbType.SelectedItem as EF.Type).ID;
                    newstaff.Price = Convert.ToDecimal(txtPrice.Text);
                    newstaff.Warranty = Convert.ToDateTime(txtWarranty.Text);
                    newstaff.IDStatus = (cmbStatus.SelectedItem as EF.Status).ID;
                    newstaff.IsDeleted = Convert.ToBoolean(txtDeleted.Text);
                    if (photostrl != null)
                    {
                        newstaff.Photo = File.ReadAllBytes(photostrl);
                    }
                    ClassHelper.AppData.Context.Product.Add(newstaff);
                    ClassHelper.AppData.Context.SaveChanges();
                    MessageBox.Show("Пользователь добавлен");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            //доб


        }

        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                PhotoUser.Source = new BitmapImage(new Uri(openFile.FileName));
                photostrl = openFile.FileName;
            }
        }
    }
}

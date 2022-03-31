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
    /// Логика взаимодействия для AddClientListWindow.xaml
    /// </summary>
    public partial class AddClientListWindow : Window
    {
        private bool IsEdit = false;
        EF.Client editStaff = new EF.Client();
        EF.Passport newPasport = new EF.Passport();
        string photostrl;
        public AddClientListWindow()
        {
            InitializeComponent();
            cmbRole.ItemsSource = ClassHelper.AppData.Context.Gender.ToList();
            cmbRole.DisplayMemberPath = "NameGender";
            cmbRole.SelectedItem = "0";
            IsEdit = false;
        }
        public AddClientListWindow(EF.Client staff,EF.Passport passport)
        {
            InitializeComponent();
            IsEdit = true;
            cmbRole.ItemsSource = ClassHelper.AppData.Context.Gender.ToList();
            cmbRole.DisplayMemberPath = "NameGender";
            tbTitle.Text = "Изменение клиента";
            btnAdd.Content = "Изменить";
            txtLastName.Text = staff.LastName;
            txtFirstName.Text = staff.FirstName;
            txtMiddleName.Text = staff.MiddleName;
            txtPhone.Text = staff.Phone;
            txtEmail.Text = staff.Email;
            cmbRole.SelectedIndex = staff.IDGender - 1;
            txtLogin.Text = Convert.ToString(staff.DateOfBirth);
            //txtPasport.Text = string.Concat(passport.PassportNumber, passport.PassportSeries);
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
            bool IsValidEmail(string email)
            {
                string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
                return isMatch.Success;
            }
            //валидация
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Поле Телефон не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Поле DateOfBirthday не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Поле Пароль не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPasport.Text))
            {
                MessageBox.Show("Поле Паспорт не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //код

            if (IsValidEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Введен некорректный Email", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPhone.Text.Length > 12)
            {
                MessageBox.Show("Поле Телефон содержит больше 12 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Int32.TryParse(txtPhone.Text, out int res))
            {
                MessageBox.Show("Поле Телефон должно состоять только из цифр", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    string series = txtPasport.Text.Substring(0, 4);
                string number = txtPasport.Text.Substring(4, 6);
                if (txtPasport.Text.Length != 10)
                    {
                        MessageBox.Show("Поле Паспорт содержит больше 10 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    editStaff.LastName = txtLastName.Text;
                    editStaff.FirstName = txtFirstName.Text;
                    editStaff.MiddleName = txtMiddleName.Text;
                    editStaff.Phone = txtPhone.Text;
                    editStaff.Email = txtEmail.Text;
                    editStaff.IDGender = (cmbRole.SelectedItem as EF.Gender).ID;
                    newPasport.PassportSeries = series;
                    newPasport.PassportNumber = number;
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
                    string series = txtPasport.Text.Substring(0,4);
                    string number = txtPasport.Text.Substring(4, 6);
                    if (txtPasport.Text.Length != 10)
                    {
                        MessageBox.Show("Поле Паспорт содержит больше 10 символов", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                //if (!Int32.TryParse(txtPasport.Text,out var a))
                //{
                //    MessageBox.Show("Поле Паспорт не содержит цифры", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                    EF.Client newstaff = new EF.Client();
                    EF.Passport newPasport = new EF.Passport();
                    newstaff.LastName = txtLastName.Text;
                    newstaff.FirstName = txtFirstName.Text;
                    newstaff.MiddleName = txtMiddleName.Text;
                    newstaff.Phone = txtPhone.Text;
                    newstaff.Email = txtEmail.Text;
                    newstaff.IDGender = (cmbRole.SelectedItem as EF.Gender).ID;
                    newPasport.PassportSeries = series;
                    newPasport.PassportNumber = number;
                    if (photostrl != null)
                    {
                        newstaff.Photo = File.ReadAllBytes(photostrl);
                    }
                    ClassHelper.AppData.Context.Client.Add(newstaff);
                    ClassHelper.AppData.Context.Passport.Add(newPasport);
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

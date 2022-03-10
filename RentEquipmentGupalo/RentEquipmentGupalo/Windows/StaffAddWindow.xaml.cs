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
    /// Логика взаимодействия для StaffAddWindow.xaml
    /// </summary>
    public partial class StaffAddWindow : Window
    {
        private bool IsEdit = false;
        EF.Staff editStaff = new EF.Staff();
        string pathPhoto;
        public StaffAddWindow()
        {
            InitializeComponent();
            cmbRole.ItemsSource = ClassHelper.AppData.Context.Role.ToList();
            cmbRole.DisplayMemberPath = "NameRole";
            cmbRole.SelectedItem = "0";
            IsEdit = false;
        }
        public StaffAddWindow(EF.Staff staff)
        {
            InitializeComponent();
            IsEdit = true;
            cmbRole.ItemsSource = ClassHelper.AppData.Context.Role.ToList();
            cmbRole.DisplayMemberPath = "NameRole";
            tbTitle.Text = "Изменение сотрудника";
            btnAdd.Content = "Изменить";
            txtLastName.Text = staff.LastName;
            txtFirstName.Text = staff.FirstName;
            txtMiddleName.Text = staff.MiddleName;
            txtPhone.Text = staff.Phone;
            txtEmail.Text = staff.Email;
            txtLogin.Text = staff.Login;
            txtPassword.Text = staff.Password;
            cmbRole.SelectedIndex = staff.IDRole - 1;
            editStaff = staff;
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
                MessageBox.Show("Поле Login не должно быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            //код
            var authUser = ClassHelper.AppData.Context.Staff.ToList().
            Where(i => i.Login == txtLogin.Text).FirstOrDefault();
            if (authUser != null && IsEdit == false)
            {
                MessageBox.Show("Данный логин занят!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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
                    editStaff.LastName = txtLastName.Text;
                    editStaff.FirstName = txtFirstName.Text;
                    editStaff.MiddleName = txtMiddleName.Text;
                    editStaff.Phone = txtPhone.Text;
                    editStaff.Email = txtEmail.Text;
                    editStaff.IDRole = (cmbRole.SelectedItem as EF.Role).ID;
                    editStaff.Login = txtLogin.Text;
                    editStaff.Password = txtPassword.Text;

                    if (photousing != null)
                    {

                        editStaff.Image = File.ReadAllBytes(pathPhoto);
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
                    EF.Staff newstaff = new EF.Staff();
                    newstaff.LastName = txtLastName.Text;
                    newstaff.FirstName = txtFirstName.Text;
                    newstaff.MiddleName = txtMiddleName.Text;
                    newstaff.Phone = txtPhone.Text;
                    newstaff.Email = txtEmail.Text;
                    newstaff.IDRole = (cmbRole.SelectedItem as EF.Role).ID;
                    newstaff.Login = txtLogin.Text;
                    newstaff.Password = txtPassword.Text;
                    ClassHelper.AppData.Context.Staff.Add(newstaff);
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

        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == true)
            {
                photousing.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;
            }
        }
    }
}

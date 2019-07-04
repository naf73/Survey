using Survey.Logic;
using Survey.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Survey.Helper;
using Survey.Exceptions;

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {

        private UserController userController = new UserController();

        #region Constructors

        public UsersPage()
        {
            InitializeComponent();
            Local();
            UpdateUsersTable();
        }

        #endregion

        private void ClearUser_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            if(CheckFillFields())
            {
                Model.User user = new Model.User()
                {
                    Login = Login.Text,
                    Password = Password.Text,
                    Surname = Surname.Text,
                    Name = Name.Text,
                    IsAdmin = IsAdmin.IsChecked == true ? true : false,
                    IsDeleted = false
                };
                try
                {
                    userController.Add(user);
                }
                catch (UserExistsException)
                {
                    MessageBox.Show("Пользователь с таким логин уже существует");
                }
                
                UpdateUsersTable();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            Model.User user = (Model.User)UsersDataGrid.SelectedItem;
            if (!(user is null))
            {
                if (CheckFillFields())
                {
                    user.Login = Login.Text;
                    user.Password = Password.Text;
                    user.Surname = Surname.Text;
                    user.Name = Name.Text;
                    user.IsAdmin = IsAdmin.IsChecked == true ? true : false;

                    try
                    {
                        userController.Edit(user);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Пользователь с таким логин уже существует");
                    }
                    UpdateUsersTable();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать в таблице строку");
            }
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            Model.User user = (Model.User)UsersDataGrid.SelectedItem;
            if (!(user is null))
            {
                if (CheckLastAdmin(user))
                {
                    if (MessageBox.Show("Удалить пользователя?", string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        userController.Remove(user.Id);
                        UpdateUsersTable();
                    }
                }
                else
                {
                    MessageBox.Show("В системе должен быть минимум 1 администратор");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать в таблице строку");
            }
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            Password.Text = Guid.NewGuid().ToString();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAdminPage();
        }

        private void UsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.User user = (Model.User)UsersDataGrid.SelectedItem;
            if(!(user is null))
            {
                FillingFields(user);
            }
            else
            {
                ClearFields();
            }
        }

        #region Methods

        private bool CheckLastAdmin(Model.User user)
        {
            if (user.IsAdmin)
                if (userController.GetAdminCount() == 1) return false;
            return true;
        }

        private bool CheckFillFields()
        {
            if (string.IsNullOrEmpty(Login.Text)) return false;
            if (string.IsNullOrEmpty(Password.Text)) return false;
            if (string.IsNullOrEmpty(Surname.Text)) return false;
            if (string.IsNullOrEmpty(Name.Text)) return false;

            return true;
        }

        private void ClearFields()
        {
            Login.Text = string.Empty;
            Password.Text = string.Empty;
            Surname.Text = string.Empty;
            Name.Text = string.Empty;
            IsAdmin.IsChecked = false;
        }

        private void FillingFields(Model.User user)
        {
            Login.Text = user.Login;
            Password.Text = user.Password;
            Surname.Text = user.Surname;
            Name.Text = user.Name;
            IsAdmin.IsChecked = user.IsAdmin;
        }

        private void UpdateUsersTable()
        {
            UsersDataGrid.ItemsSource = userController.GetAll();
        }

        #endregion

        #region Localization

        private void Local()
        {
            ComeBack.Content = LangPages.UsersPage.KcBack;
            Workers.Text = LangPages.UsersPage.TblWorkers;
            Log.Text = LangPages.UsersPage.TbxLogin;
            SurName.Text = LangPages.UsersPage.TbxSurName;
            FName.Text = LangPages.UsersPage.TbxName;
            ClearUser.Content = LangPages.UsersPage.KcClear;
            AddUser.Content = LangPages.UsersPage.KcAdd;
            EditUser.Content = LangPages.UsersPage.KcChange;
            RemoveUser.Content = LangPages.UsersPage.KcDel;
            DgLog.Header = LangPages.UsersPage.DgLogin;
            DgName.Header = LangPages.UsersPage.DgName;
            DgSurName.Header = LangPages.UsersPage.DgSurName;
        }

        #endregion
        
    }
}

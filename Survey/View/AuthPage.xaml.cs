using Survey.Logic;
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

namespace Survey.View
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private UserController userController = new UserController();

        public AuthPage()
        {
            InitializeComponent();
            userController.AddAdmin();
            Login.Focus();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var user = userController.GetUserByPass(Login.Text, Password.Password);
            if (!(user is null))
            {
                if (user.IsAdmin)
                {
                    Navigated.GoToAdminPage();
                }
                else
                {
                    Navigated.GoToUserPage(user);
                }
            }
            else
            {
                MessageBox.Show("Не правильный логин / пароль");
            }
        }
    }
}

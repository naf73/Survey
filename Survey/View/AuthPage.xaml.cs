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
using Survey.Helper;

namespace Survey.View
{
    /// <summary>
    /// Interaction logic for AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {

       

        private class Item
        {
            public Item(int value, string text) { Value = value; Text = text; }
            public int Value { get; set; }
            public string Text { get; set; }
            public override string ToString() { return Text; }
        }
        private UserController userController = new UserController();

        public AuthPage()
        {
            InitializeComponent();
            userController.AddAdmin();
            Login.Focus();

            string I = "Русский";
            string II = "Engish";
            
            comboBox1.Items.Add(new Item(1, I));
            comboBox1.Items.Add(new Item(2, II));
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
        #region Локализация

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Item item = comboBox1.Items[comboBox1.SelectedIndex] as Item;
            // MessageBox.Show(item.Value.ToString());

            if (comboBox1.SelectedIndex == 0)
            {
                LANG.ChangeLang(Lang.RUS);
            }
            else
            {
                LANG.ChangeLang(Lang.ENG);
            }

            TLog.Text = LangPages.AuthPage.TblLogin;
            TPas.Text = LangPages.AuthPage.TblPassword;
            //TLang.Text = LangPages.AuthPage.TblLanguage;
            TSing.Text = LangPages.AuthPage.TblSingIn;
            Enter.Content = LangPages.AuthPage.KcEntre;

        }     
              

        #endregion
    }
}

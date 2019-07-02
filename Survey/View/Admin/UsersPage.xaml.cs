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

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            Local();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAdminPage();
        }

        #region Localization

        private void Local()
        {
            ComeBack.Content = LangPages.UsersPage.KcBack;
            Workers.Text = LangPages.UsersPage.TblWorkers;
            Log.Text = LangPages.UsersPage.TbxLogin;
            SurName.Text = LangPages.UsersPage.TbxSurName;
            FName.Text = LangPages.UsersPage.TbxName;
            Role.Text = LangPages.UsersPage.CbxRole;
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

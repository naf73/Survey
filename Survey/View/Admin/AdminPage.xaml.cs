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
using Survey.Model;

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        List<Model.User> users = new List<Model.User>();

        public AdminPage()
        {
            InitializeComponent();
            Roles.ItemsSource = Enum.GetValues(typeof(TypeRole)).Cast<TypeRole>();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAuthPage();
        }

        private void ClearUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

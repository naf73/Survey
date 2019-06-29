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

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }

        private void NewCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LookTests_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToSurveysPage();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAdminPage();
        }
    }
}

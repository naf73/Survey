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
    /// Interaction logic for SurveyPage.xaml
    /// </summary>
    public partial class SurveyPage : Page
    {
        public SurveyPage()
        {
            InitializeComponent();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToSurveysPage();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

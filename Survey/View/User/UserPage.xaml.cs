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

namespace Survey.View.User
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private Model.User _user;
        private List<Model.Survey> _surveys;

        public UserPage(Model.User user)
        {
            InitializeComponent();
            _user = user;
            UserName.Text = string.Format("{0} {1}", _user.Surname, _user.Name);
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAuthPage();
        }

        private void GoToTest_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToQuestionPage();
        }

        #region Methods

        

        #endregion
    }
}

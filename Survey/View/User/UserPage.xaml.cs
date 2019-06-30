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

namespace Survey.View.User
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private Model.User _user;
        private List<Model.Survey> _surveys;

        private SurveyController surveyController = new SurveyController();

        public UserPage(Model.User user)
        {
            InitializeComponent();
            Local();
            _user = user;
            UserName.Text = string.Format("{0} {1}", _user.Surname, _user.Name);
            _surveys = surveyController.GetByUserId(_user.Id);
            UpdateSurveysTable();
            if (_surveys.Count > 0)
            {
                GoToTest.Visibility = Visibility.Visible;
            }
            else
            {
                GoToTest.Visibility = Visibility.Collapsed;
            }
            string bestSurvey = surveyController.GetTheBestSurveyOfUser(_user.Id);
            if (!string.IsNullOrEmpty(bestSurvey)) LabelBestSurvey.Content = bestSurvey;

        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAuthPage();
        }

        private void GoToTest_Click(object sender, RoutedEventArgs e)
        {
            Model.Survey survey = _surveys[0];
            if (SurveysGrid.SelectedIndex != -1) survey = (Model.Survey)SurveysGrid.SelectedItem;
            Navigated.GoToQuestionPage(survey, _user);
        }

        #region Methods

        private void UpdateSurveysTable()
        {
            _surveys = surveyController.GetByUserId(_user.Id);
            SurveysGrid.ItemsSource = _surveys;
        }

        #endregion
        #region Localization       
        private void Local()
        {
            ComeBack.Content = LangPages.UserPage.KcBack;
            GoToTest.Content = LangPages.UserPage.KcGoSurvey;
            LabelMotivation.Content = LangPages.UserPage.KcBestResult;
            LabelBestSurvey.Content = LangPages.UserPage.KcAbsent;
            DgCat.Header = LangPages.UserPage.DgCategory;
            DgTitle.Header = LangPages.UserPage.DgTitle;
            DgTime.Header = LangPages.UserPage.DgTime;
        }
        #endregion

    }
}

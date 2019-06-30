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

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for SurveyPage.xaml
    /// </summary>
    public partial class SurveyPage : Page
    {
        private Model.Survey _survey;

        private SurveyController surveyController = new SurveyController();

        public SurveyPage(Model.Survey survey)
        {
            InitializeComponent();
            _survey = survey;
            UpdateFields();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToSurveysPage(_survey.CategoryId);
        }

        private void ManageSurvey_Click(object sender, RoutedEventArgs e)
        {
            if((bool)ManageSurvey.Tag)
            {

            }
            else
            {

            }
        }

        #region Methods

        private void UpdateFields()
        {
            if (_survey.Id != 0)
            {
                SurveyName.Text = _survey.Name;
                ManageSurvey.Content = "Изменить";
                ManageSurvey.Tag = false;
            }
            else
            {
                ManageSurvey.Content = "Создать";
                ManageSurvey.Tag = true;
            }
        }

        #endregion
    }
}

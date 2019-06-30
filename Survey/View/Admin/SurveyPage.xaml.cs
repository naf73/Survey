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
            Local();
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

        #region Localization
        private void Local()
        {
            ComeBack.Content = LangPages.SurveyPage.KcBack;
            ListQuestSurvey.Text = LangPages.SurveyPage.TblListQuestSurvey;
            LabelCategoryName.Content = LangPages.SurveyPage.LNameSurvey;
            ManageSurvey.Content = LangPages.SurveyPage.KcCreate;
            QuestionAdd.Content = LangPages.SurveyPage.KcAdd;
            QuestionEdit.Content = LangPages.SurveyPage.KcChange;
            QuestionRemove.Content = LangPages.SurveyPage.KcDel;
            DgQuestion.Header = LangPages.SurveyPage.DgQuestion;
            LabelQuestion.Content = LangPages.SurveyPage.DgAnswer;
            LabelQuestionText.Content = LangPages.SurveyPage.LText;
            LabelPicture.Content = LangPages.SurveyPage.LPictures;
            QuestionPictureAdd.Content = LangPages.SurveyPage.KcAddPictures;
            QuestionPictureRemove.Content = LangPages.SurveyPage.KcPicturesRemove;
            LabelAnswers.Content = LangPages.SurveyPage.LAnswers;
            AnswerAdd.Content = LangPages.SurveyPage.KcAdd;
            AnswerEdit.Content = LangPages.SurveyPage.KcChange;
            AnswerRemove.Content = LangPages.SurveyPage.KcDel;
            ClearQuestionFields.Content = LangPages.SurveyPage.KcClearFields;
            LabelAnswer.Content = LangPages.SurveyPage.LAnswer;
            LabelAnswerText.Content = LangPages.SurveyPage.LText;
            LabelAnswerPicture.Content = LangPages.SurveyPage.LPictures;
            AnswerPictureAdd.Content = LangPages.SurveyPage.KcAddPictures;
            AnswerPictureRemove.Content = LangPages.SurveyPage.KcPicturesRemove;
            ClearAnswerFields.Content = LangPages.SurveyPage.KcClearFields;
            DgAnswer.Header = LangPages.SurveyPage.DgAnswer;



        }
        #endregion
    }
}

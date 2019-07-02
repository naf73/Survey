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
        QuestionController questionController = new QuestionController();

        public SurveyPage(Model.Survey survey)
        {
            InitializeComponent();
            _survey = survey;
            UpdateFields();
            UpdateQuestionTable();
            Local();
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToSurveysPage(_survey.CategoryId);
        }

        private void ManageSurvey_Click(object sender, RoutedEventArgs e)
        {

            throw new NotImplementedException();

            if((bool)ManageSurvey.Tag)
            {

            }
            else
            {

            }
        }

        #region Question

        private void QuestionAdd_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QuestionEdit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QuestionRemove_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QuestionPictureAdd_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QuestionPictureRemove_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearQuestionFields_Click(object sender, RoutedEventArgs e)
        {
            MethodClearQuestionFields();
        }

        private void QuestionsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateQuestionFields((Question)QuestionsDataGrid.SelectedItem);
        }

        #endregion

        #region Answer        

        private void AnswerAdd_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AnswerEdit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AnswerRemove_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AnswerPictureAdd_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AnswerPictureRemove_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearAnswerFields_Click(object sender, RoutedEventArgs e)
        {
            MethodClearAnswerFields();
        }      

        private void AnswersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAnswerFields((Answer)AnswersDataGrid.SelectedItem);
        }

        #endregion

        #region Methods

        private string GetPathPicture()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|JPEG (*.jpeg)|*jpeg|PNG (*.png)|*.png|All files (*.*)|*.*";
            dialog.FilterIndex = 2;

            Nullable<bool> result = dialog.ShowDialog();

            return result == true ? dialog.FileName : string.Empty;
        }

        private void GetPicture(Image image)
        {
            string path = GetPathPicture();
            if (!string.IsNullOrEmpty(path))
            {
                image.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            }
            else
            {
                image.Source = null;
            }
        }

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

        private void UpdateQuestionTable()
        {
            if(!(_survey is null))
            {
                QuestionsDataGrid.ItemsSource = questionController.Get(_survey.Id);
            }
            else
            {
                QuestionsDataGrid.ItemsSource = null;
            }
        }

        private void UpdateQuestionFields(Question question)
        {
            if(!(question is null))
            {
                QuestionText.Text = question.Text;
                QuestionPicture.Source = ConvertPicture.ByteArrayToImage(question.Foto);
                UpdateAnswerTable(question);
            }
            else
            {
                MethodClearQuestionFields();
            }
        }

        private void MethodClearQuestionFields()
        {
            QuestionText.Clear();
            QuestionPicture.Source = null;
            AnswersDataGrid.ItemsSource = null;
        }

        private void UpdateAnswerTable(Question question)
        {
            if (!(question is null))
            {
                AnswersDataGrid.ItemsSource = question.Answer;
            }
            else
            {
                MethodClearAnswerFields();
            }
        }

        private void UpdateAnswerFields(Answer answer)
        {
            if (!(answer is null))
            {
                AnswerText.Text = answer.Text;
                AnswerPicture.Source = ConvertPicture.ByteArrayToImage(answer.Foto);
            }
            else
            {
                MethodClearAnswerFields();
            }
        }

        private void MethodClearAnswerFields()
        {
            AnswerText.Clear();
            AnswerPicture.Source = null;
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

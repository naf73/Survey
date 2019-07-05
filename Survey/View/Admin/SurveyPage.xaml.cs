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
        private List<Answer> _answers = new List<Answer>();

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
            if (!int.TryParse(SurveyTime.Text, out int time))
            {
                MessageBox.Show(LangPages.MBox.TimeEntryError);
                return;
            }
            if(string.IsNullOrEmpty(SurveyName.Text))
            {
                MessageBox.Show(LangPages.MBox.ErrorEnteringPollName);
                return;
            }
            if ((bool)ManageSurvey.Tag)
            {
                _survey.Name = SurveyName.Text;
                _survey.Time = time;
                surveyController.Add(_survey);
                ManageSurvey.Tag = false;
                GridSurvey.Visibility = Visibility.Visible;
            }
            else
            {
                _survey.Name = SurveyName.Text;
                _survey.Time = time;
                surveyController.Edit(_survey);
            }
        }

        #region Question

        private void QuestionAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFillingQuestionFields())
            {
                if(CheckAnswersCount())
                {
                    if (CheckExistRightAnswer()) 
                    {
                        questionController.Add(new Question()
                        {
                            SurveyId = _survey.Id,
                            Text = !string.IsNullOrEmpty(QuestionText.Text) ? QuestionText.Text : string.Empty,
                            Foto = QuestionPicture.Source != null ? ConvertPicture.BitmapImageToByteArray((BitmapImage)QuestionPicture.Source) : null
                        }, _answers);
                        _answers.Clear();
                        UpdateQuestionTable();
                    }
                    else
                    {
                        MessageBox.Show(LangPages.MBox.MissingCorrectAnswer);
                    }
                }
                else
                {
                    MessageBox.Show(LangPages.MBox.NeedToAddQuestionAnswers);
                }                
            }
            else
            {
                MessageBox.Show(LangPages.MBox.NotAllFieldsInTheQuestionAreFilled);
            }
        }

        private void QuestionEdit_Click(object sender, RoutedEventArgs e)
        {
            Question question = (Question)QuestionsDataGrid.SelectedItem;
            if (!(question is null))
            {
                if (CheckFillingQuestionFields())
                {
                    if (CheckAnswersCount())
                    {
                        if (CheckExistRightAnswer())
                        {
                            question.SurveyId = _survey.Id;
                            question.Text = !string.IsNullOrEmpty(QuestionText.Text) ? QuestionText.Text : string.Empty;
                            question.Foto = QuestionPicture.Source != null ? ConvertPicture.BitmapImageToByteArray((BitmapImage)QuestionPicture.Source) : null;
                            questionController.Edit(question, _answers);
                            _answers.Clear();
                            UpdateQuestionTable();
                        }
                        else
                        {
                            MessageBox.Show(LangPages.MBox.MissingCorrectAnswer);
                        }
                    }
                    else
                    {
                        MessageBox.Show(LangPages.MBox.NeedToAddQuestionAnswers);
                    }
                }
                else
                {
                    MessageBox.Show(LangPages.MBox.NotAllFieldsInTheQuestionAreFilled);
                }
            }
        }

        private void QuestionRemove_Click(object sender, RoutedEventArgs e)
        {
            Question question = (Question)QuestionsDataGrid.SelectedItem;

            if(!(question is null))
            {
                if (MessageBox.Show(LangPages.MBox.DelQuestion, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    questionController.Remove(question.Id);
                    UpdateQuestionTable();
                }
            }
            else
            {
                MessageBox.Show(LangPages.MBox.DelQuestionSpecifyIt);
            }
        }

        private void QuestionPictureAdd_Click(object sender, RoutedEventArgs e)
        {
            GetPicture(QuestionPicture);
        }

        private void QuestionPictureRemove_Click(object sender, RoutedEventArgs e)
        {
            QuestionPicture.Source = null;
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
            if (CheckFillingAnswerFields())
            {
                _answers.Add(new Answer()
                {
                    Text = AnswerText.Text,
                    Foto = !(AnswerPicture.Source is null) ? ConvertPicture.BitmapImageToByteArray((BitmapImage)AnswerPicture.Source) : null,
                    IsDeleted = false,
                    IsTrue = IsTrueAnswer.IsChecked == true ? true : false
                });                
            }
            else
            {
                MessageBox.Show(LangPages.MBox.NotAllFieldsInTheAnswerAreFilled);
            }
            MethodClearAnswerFields();
            UpdateAnswerTable();
        }

        private void AnswerEdit_Click(object sender, RoutedEventArgs e)
        {
            Answer current_answer = (Answer)AnswersDataGrid.SelectedItem;
            if(!(current_answer is null))
            {
                current_answer.Text = AnswerText.Text;
                current_answer.Foto = !(AnswerPicture.Source is null) ? ConvertPicture.BitmapImageToByteArray((BitmapImage)AnswerPicture.Source) : null;
                current_answer.IsTrue = IsTrueAnswer.IsChecked == true ? true : false;
            }
            else
            {
                MessageBox.Show(LangPages.MBox.YouMustSpecifyTheAnswerToEdit);
            }
            MethodClearAnswerFields();
            UpdateAnswerTable();
        }

        private void AnswerRemove_Click(object sender, RoutedEventArgs e)
        {
            Answer current_answer = (Answer)AnswersDataGrid.SelectedItem;
            if(!(current_answer is null))
            {
                if (MessageBox.Show(LangPages.MBox.DelAnswer, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _answers.Remove(current_answer);
                    UpdateAnswerTable();
                }
            }
            else
            {
                MessageBox.Show(LangPages.MBox.YouMustSpecifyTheAnswerToRemove);
            }
        }

        private void AnswerPictureAdd_Click(object sender, RoutedEventArgs e)
        {
            GetPicture(AnswerPicture);
        }

        private void AnswerPictureRemove_Click(object sender, RoutedEventArgs e)
        {
            AnswerPicture.Source = null;
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

            bool? result = dialog.ShowDialog();

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
                SurveyTime.Text = _survey.Time.ToString();
                ManageSurvey.Content = LangPages.MBox.Change;
                ManageSurvey.Content = LangPages.MBox.Del;
                ManageSurvey.Tag = false;
                GridSurvey.Visibility = Visibility.Visible;
            }
            else
            {
                ManageSurvey.Content = LangPages.MBox.Creat;
                ManageSurvey.Tag = true;
                GridSurvey.Visibility = Visibility.Hidden;
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
                _answers = question.Answer.ToList();
                UpdateAnswerTable();
            }
            else
            {
                MethodClearQuestionFields();
            }
        }

        private bool CheckFillingQuestionFields()
        {
            if (_answers.Count == 0) return false;
            return !string.IsNullOrEmpty(QuestionText.Text) ||
                    QuestionPicture.Source != null;
        }

        private void MethodClearQuestionFields()
        {
            QuestionText.Clear();
            QuestionPicture.Source = null;
            _answers.Clear();
            UpdateAnswerTable();
        }

        private void UpdateAnswerTable()
        {
            if (!(_answers is null))
            {
                AnswersDataGrid.ItemsSource = null;
                AnswersDataGrid.ItemsSource = _answers;
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
                IsTrueAnswer.IsChecked = answer.IsTrue;
            }
            else
            {
                MethodClearAnswerFields();
            }
        }

        private bool CheckFillingAnswerFields()
        {
            return !string.IsNullOrEmpty(AnswerText.Text) ||
                    AnswerPicture.Source != null;
        }

        private bool CheckAnswersCount()
        {
            return _answers.Count > 0 ? true : false;
        }

        private bool CheckExistRightAnswer()
        {
            return _answers.Count(a => a.IsTrue == true) > 0 ? true : false;
        }

        private void MethodClearAnswerFields()
        {
            AnswerText.Clear();
            AnswerPicture.Source = null;
            IsTrueAnswer.IsChecked = false;
        }

        #endregion

        #region Localization

        private void Local()
        {
            ComeBack.Content = LangPages.SurveyPage.KcBack;
            ListQuestSurvey.Text = LangPages.SurveyPage.TblListQuestSurvey;
            LabelSurveyName.Content = LangPages.SurveyPage.LNameSurvey;
            ManageSurvey.Content = LangPages.SurveyPage.KcCreate;
            QuestionAdd.Content = LangPages.SurveyPage.KcAdd;
            QuestionEdit.Content = LangPages.SurveyPage.KcChange;
            QuestionRemove.Content = LangPages.SurveyPage.KcDel;
            DgQuestion.Header = LangPages.SurveyPage.DgQuestion;
            LabelQuestion.Content = LangPages.SurveyPage.DgQuestion;
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

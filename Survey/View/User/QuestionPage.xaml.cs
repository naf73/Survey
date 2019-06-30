using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Survey.Model;
using Survey.Logic;
using Survey.Helper;


namespace Survey.View.User
{
    /// <summary>
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page, INotifyPropertyChanged
    {
        private Model.Survey _survey;
        private Timer aTimer;
        private MediaPlayer media;
        private int sec, min, hour;
        private string _time;
        private int number;

        private int right_answer;

        private Model.User _user;

        private SurveyController surveyController = new SurveyController();

        public QuestionPage(Model.Survey survey, Model.User user)
        {
            InitializeComponent();
            // ===
            _survey = survey;
            _user = user;
            media = new MediaPlayer();
            media.Open(new Uri("Resources/pole_letter_correct.mp3", UriKind.Relative));
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            DateTime limitTime = new DateTime(0, 0);
            limitTime = limitTime.AddMinutes(_survey.Time);
            hour = limitTime.Hour;
            min = limitTime.Minute;
            sec = limitTime.Second;
            Times = string.Format("{0:00}:{1:00}:{2:00}", hour, min, sec);
            this.DataContext = this;
            number = 0;
            right_answer = 0;
            ShowQuestion(number);

            #region Локализация

            NextQuestion.Content = LangPages.QuestionPage.KcNext;

            #endregion
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckGetUserAnswer())
            {
                MessageBox.Show("Выберите ответ");
                return;
            }

            if (CheckAnswerCount() && CheckIsRightUserAnswer())
            {
                SoundRightAnswer();
                right_answer++;
            }

            number++;

            if (CheckFinishedSurvey())
            {
                ShowQuestion(number);
            }
            else
            {
                EndingSurvey();
            }
        }

        private void EndingSurvey()
        {
            double result = MarkSurvey();
            aTimer.Stop();
            surveyController.SetMark(_survey.Id, _user.Id, result);
            ShowResult(result);
            Navigated.GoToUserPage(_user);
        }

        private double MarkSurvey()
        {
            return (((double)right_answer) / _survey.Question.Count()) * 100;
        }

        private void SoundRightAnswer()
        {
            media.Play();
            media.Position = new TimeSpan(0);
        }

        private void ShowResult(double result)
        {
            MessageBox.Show(string.Format("Тест завершен\nВаш результат: {0} %", result));
        }

        private bool CheckFinishedSurvey()
        {
            return !(number == _survey.Question.Count);
        }

        private bool CheckIsRightUserAnswer()
        {
            List<CheckBox> checkBoxs = Answers.Children.Cast<CheckBox>()
                                                       .Where(c => c.IsChecked == true)
                                                       .ToList();

            List<Answer> answers = _survey.Question.ToList()[number]
                                                             .Answer
                                                             .Where(a => a.IsTrue == true).ToList();
            int trueAnswerCount = 0;
            foreach (var answer in answers)
            {
                var chkbx = checkBoxs.FirstOrDefault(c => (int)c.Tag == answer.Id);
                if (!(chkbx is null)) trueAnswerCount++;
            }
            return answers.Count == trueAnswerCount;
        }

        private bool CheckAnswerCount()
        {
            return Answers.Children.Cast<CheckBox>()
                                   .Where(c => c.IsChecked == true)
                                   .ToList()
                                   .Count == _survey.Question.ToList()[number]
                                                             .Answer
                                                             .Where(a => a.IsTrue == true)
                                                             .Count();
        }

        private bool CheckGetUserAnswer()
        {
            return Answers.Children.Cast<CheckBox>()
                                   .Where(c => c.IsChecked == true)
                                   .ToList()
                                   .Count > 0;
        }

        private void ShowQuestion(int number)
        {
            string text = _survey.Question.ToList()[number].Text;
            byte[] picture = _survey.Question.ToList()[number].Foto;
            if (!(text is null)) Question.Content = text;
            if (!(picture is null)) Foto.Source = ConvertPicture.ByteArrayToImage(picture);
            ShowAnswer(_survey.Question.ToList()[number].Answer.ToList());
        }

        private void ShowAnswer(List<Answer> answers)
        {
            Answers.Children.Clear();
            foreach (var answer in answers)
            {
                Answers.Children.Add(new CheckBox()
                {
                    Content = answer.Text,
                    Style = (Style)FindResource("Answer"),
                    Tag = answer.Id
                });
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Times = string.Format("{0:00}:{1:00}:{2:00}", hour, min, sec);
            if (hour == 0 && min == 0 && sec == 0)
            {
                EndingSurvey();
            }
            else
            {
                if (sec == 0) { sec = 60; min--; }
                if (min == 0 && hour > 0) { min = 59; hour--; }
                sec--;
            }
        }

        public string Times
        {
            get { return _time; }
            private set
            {
                _time = value;
                OnPropertyChanged("Times");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }        
    }
}

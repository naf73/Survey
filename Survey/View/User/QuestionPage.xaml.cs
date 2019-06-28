using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        private Model.Survey _survey = null;
        private Timer timer = null;

        public QuestionPage(Model.Survey survey)
        {
            InitializeComponent();
            // ===
            _survey = survey;

        }
    }
}

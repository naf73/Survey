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
    /// Interaction logic for SurveysPage.xaml
    /// </summary>
    public partial class SurveysPage : Page
    {
        private Model.Survey _survey;
        private Category _category;

        private CategoryController categoryController = new CategoryController();
        private SurveyController surveyController = new SurveyController();

        public SurveysPage(int categoryId)
        {
            InitializeComponent();
            _category = categoryController.GetById(categoryId);
            UpdateFields();
            Local();
        }

        #region Events

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToCategoriesPage();
        }

        private void ManageCategory_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)ManageCategory.Tag)
            {
                if (!string.IsNullOrWhiteSpace(CategoryName.Text))
                {
                    _category = new Category()
                    {
                        Name = CategoryName.Text,
                        IsDeleted = false
                    };
                    categoryController.Add(_category);
                    ManageCategory.Content = LangPages.MBox.Change;
                    ManageCategory.Tag = false;
                    MessageBox.Show(LangPages.MBox.AddCatToSystem);
                }
                else
                {
                    MessageBox.Show(LangPages.MBox.YouMustSpecifyCategoryName);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(CategoryName.Text))
                {
                    categoryController.Edit(_category.Id, CategoryName.Text);
                    MessageBox.Show(LangPages.MBox.CatChange);
                }
                else
                {
                    MessageBox.Show(LangPages.MBox.EmptyFieldNotAll);
                    return;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (_category is null)
            {
                MessageBox.Show(LangPages.MBox.MustCreateCat);
                return;
            }
            Navigated.GoToSurveyPage(new Model.Survey()
            {
                CategoryId = _category.Id
            });
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!(_survey is null)) Navigated.GoToSurveyPage(_survey);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (!(_survey is null))
            {
                if (MessageBox.Show(LangPages.MBox.DelSurvey, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    surveyController.Remove(_survey.Id);
                    UpdateFields();
                }
            }
            else
            {
                MessageBox.Show(LangPages.MBox.YouMustSpecifySurveyToDelete);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SurveysDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectSurvey();
        }

        private void SurveysDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectSurvey();
            if (!(_survey is null)) Navigated.GoToSurveyPage(_survey);
        }

        #endregion

        #region Methods

        private void SelectSurvey()
        {
            Model.Survey survey = (Model.Survey)SurveysDataGrid.SelectedItem;
            if(!(survey is null))
            {
                _survey = survey;
            }
            else
            {
                _survey = null;
            }
        }

        private void UpdateFields()
        {
            if(!(_category is null))
            {
                CategoryName.Text = _category.Name;
                SurveysDataGrid.ItemsSource = surveyController.GetByCategoryId(_category.Id);
                ManageCategory.Content = LangPages.MBox.Change;
                ManageCategory.Tag = false;
            }
            else
            {
                ManageCategory.Content = LangPages.MBox.Creat;
                ManageCategory.Tag = true;
            }
        }

        #endregion

        #region Localization
        private void Local()
        {
            ComeBack.Content = LangPages.SurveysPage.KcBack;
            ListSurveys.Text = LangPages.SurveysPage.TblListSurveys;
            LabelCategoryName.Content = LangPages.SurveysPage.LCatName;
            ManageCategory.Content = LangPages.SurveysPage.KcCreate;
            Add.Content = LangPages.SurveysPage.KcAdd;
            Edit.Content = LangPages.SurveysPage.KcChange;
            Remove.Content = LangPages.SurveysPage.KcDel;
            Export.Content = LangPages.SurveysPage.KcExport;
            Import.Content = LangPages.SurveysPage.KcImport;
            Title.Header = LangPages.SurveysPage.DgTitle;
            Time.Header = LangPages.SurveysPage.DgTime;
        }

        #endregion        
    }
}

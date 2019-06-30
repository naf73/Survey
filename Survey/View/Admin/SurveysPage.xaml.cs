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
    /// Interaction logic for SurveysPage.xaml
    /// </summary>
    public partial class SurveysPage : Page
    {
        private Category _category;

        private CategoryController categoryController = new CategoryController();
        private SurveyController surveyController = new SurveyController();

        public SurveysPage(int categoryId)
        {
            InitializeComponent();
            _category = categoryController.GetById(categoryId);
            UpdateFields();
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
                    ManageCategory.Content = "Изменить";
                    ManageCategory.Tag = false;
                    MessageBox.Show("Категория добавлена в систему");
                }
                else
                {
                    MessageBox.Show("Необходимо задать имя категории");
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(CategoryName.Text))
                {
                    categoryController.Edit(_category.Id, CategoryName.Text);
                    MessageBox.Show("Категория изменена");
                }
                else
                {
                    MessageBox.Show("Пусто поле не допускается");
                    return;
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (_category is null)
            {
                MessageBox.Show("Необходимо создать категорию");
                return;
            }
            Navigated.GoToSurveyPage(new Model.Survey()
            {
                CategoryId = _category.Id
            });
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        private void UpdateFields()
        {
            if(!(_category is null))
            {
                CategoryName.Text = _category.Name;
                SurveysDataGrid.ItemsSource = surveyController.GetByCategoryId(_category.Id);
                ManageCategory.Content = "Изменить";
                ManageCategory.Tag = false;
            }
            else
            {
                ManageCategory.Content = "Создать";
                ManageCategory.Tag = true;
            }
        }

        #endregion
        
    }
}

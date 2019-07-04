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
using Microsoft.Win32;
using Survey.Logic.JsonPorter;

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        private Category _category = null;

        CategoryController categoryController = new CategoryController();

        public CategoriesPage()
        {
            InitializeComponent();
            UpdateCategoriesTable();
            Local();
        }

        #region Events        

        private void LookTests_Click(object sender, RoutedEventArgs e)
        {
            if (!(_category is null))
            {
                Navigated.GoToSurveysPage(_category.Id);
            }
            else
            {
                Navigated.GoToSurveysPage(0);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAdminPage();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToSurveysPage(0);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!(_category is null)) Navigated.GoToSurveysPage(_category.Id);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (!(_category is null))
            {
                if (MessageBox.Show("Удалить категорию?", string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    categoryController.Remove(_category.Id);
                    UpdateCategoriesTable();
                }
            }
            else
            {
                MessageBox.Show("Необходимо указать категорию для удаления");
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В следующей версии");	
		}

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("В следующей версии");
        }

        private void CategoriesDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectCategory();
            if (!(_category is null)) Navigated.GoToSurveysPage(_category.Id);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectCategory();
        }

        #endregion

        #region Methods

        private void UpdateCategoriesTable()
        {
            CategoriesDataGrid.ItemsSource = categoryController.Get();
        }

        private void SelectCategory()
        {
            Category category = (Category)CategoriesDataGrid.SelectedItem;
            if (!(category is null))
            {
                _category = category;
            }
            else
            {
                _category = null;
            }
        }

        #endregion

        #region Localization

        private void Local()
        {
            ComeBack.Content = LangPages.CategoriesPage.KcBack;
            LabelPage.Text = LangPages.CategoriesPage.DgCatSurveys;
            Add.Content = LangPages.CategoriesPage.KcAdd;
            Edit.Content = LangPages.CategoriesPage.KcChange;
            Remove.Content = LangPages.CategoriesPage.KcDel;
            Export.Content = LangPages.CategoriesPage.KcExport;
            Import.Content = LangPages.CategoriesPage.KcImport;
            CatTests.Header = LangPages.CategoriesPage.DgCatTests;

        }

        #endregion
    }
}

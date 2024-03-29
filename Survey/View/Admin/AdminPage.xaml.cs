﻿using Survey.Logic;
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
using Survey.Model;
using Survey.Helper;

namespace Survey.View.Admin
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        List<Model.User> users = new List<Model.User>();

        StatisticsController statisticsController = new StatisticsController();

        public AdminPage()
        {
            InitializeComponent();
            StatEmployeesDataGrid.ItemsSource = statisticsController.GetStatEmployees();
            Local();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToAuthPage();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToUsersPage();
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Navigated.GoToCategoriesPage();
        }

        private void UpdateStatSurveyTable()
        {
            StatEmployee employee = (StatEmployee)StatEmployeesDataGrid.SelectedItem;
            if (employee != null)
            {
                StatSurveysDataGrid.ItemsSource = statisticsController.GetStatSurveys(employee.Id);
            }
        }

        private void StatEmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStatSurveyTable();
        }

        #region Localization

        private void Local()
        {
            Users.Content = LangPages.AdminPage.KcWorkers;
            Surveys.Content = LangPages.AdminPage.KcSurveys;
            DName.Header = LangPages.AdminPage.DgName;
            DSurName.Header = LangPages.AdminPage.DgSurvey;
            DRating.Header = LangPages.AdminPage.DgRating;
            DSur.Header = LangPages.AdminPage.DgSurvey;
            DCat.Header = LangPages.AdminPage.DgCategory;
            DTotal.Header = LangPages.AdminPage.DgTotal;
            Exit.Content = LangPages.AdminPage.KcExit;
            TbStat.Text = LangPages.AdminPage.DgStatiatic;
        }

        #endregion
    }
}

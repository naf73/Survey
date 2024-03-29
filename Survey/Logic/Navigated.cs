﻿using Survey.Model;
using Survey.View;
using Survey.View.Admin;
using Survey.View.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Survey.Logic
{
    public static class Navigated
    {
        private static Frame _frame;

        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        public static void GoToAuthPage()
        {
            _frame.Navigate(new AuthPage());
        }

        public static void GoToAdminPage()
        {
            _frame.Navigate(new AdminPage());
        }

        public static void GoToSurveysPage(int categoryId)
        {
            _frame.Navigate(new SurveysPage(categoryId));
        }

        public static void GoToSurveyPage(Model.Survey survey)
        {
            _frame.Navigate(new SurveyPage(survey));
        }

        public static void GoToQuestionPage(Model.Survey survey, Model.User user)
        {
            _frame.Navigate(new QuestionPage(survey, user));
        }

        public static void GoToUsersPage()
        {
            _frame.Navigate(new UsersPage());
        }

        public static void GoToUserPage(User user)
        {   
            _frame.Navigate(new UserPage(user));
        }

        public static void GoToCategoriesPage()
        {
            _frame.Navigate(new CategoriesPage());
        }
    }
}

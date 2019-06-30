using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Helper
{

    public enum Lang
    {
        RUS,
        ENG,
    }
    class LANG
    {
  
        public static void ChangeLang(Lang lang)
        {
            switch (lang)
            {
                case Lang.RUS:
                    #region AdminPage

                    LangPages.AdminPage.DgCategory = "Категория";
                    LangPages.AdminPage.DgName = "Имя";
                    LangPages.AdminPage.DgRating = "Рейтинг в %";
                    LangPages.AdminPage.DgStatiatic = "Статистика";
                    LangPages.AdminPage.DgSurvey = "Опрос";
                    LangPages.AdminPage.DgTotal = "Итого в %";
                    LangPages.AdminPage.DgSurName = "Фамилия";
                    LangPages.AdminPage.KcExit = "Выход";
                    LangPages.AdminPage.KcSurveys = "Опросы";
                    LangPages.AdminPage.KcWorkers = "Сотрудники";

                    #endregion

                    #region CategoriesPage

                    LangPages.CategoriesPage.DgCatSurveys = "Категории опросов";
                    LangPages.CategoriesPage.KcChangeCat = "Изменить категорию";
                    LangPages.CategoriesPage.KcDelCat = "Удалить категорию";
                    LangPages.CategoriesPage.KcExit = "Выход";
                    LangPages.CategoriesPage.KcLookSurveys = "Посмотреть Опросы";
                    LangPages.CategoriesPage.KcNewCat = "Новая категория";

                    #endregion

                    #region SurveyPage

                    LangPages.SurveyPage.KcAdd = "Добавить";
                    LangPages.SurveyPage.KcBack = "Назад";
                    LangPages.SurveyPage.KcChange = "Изменить";
                    LangPages.SurveyPage.KcDel = "Удалить";
                    LangPages.SurveyPage.TblQuestion = "Вопрос";
                    LangPages.SurveyPage.TblQuestions = "Вопросы";
                    LangPages.SurveyPage.TblReports = "Ответы";

                    #endregion

                    #region SurveysPage

                    LangPages.SurveysPage.DgNumber = "Номер";
                    LangPages.SurveysPage.DgTime = "Время";
                    LangPages.SurveysPage.DgTitle = "Название";
                    LangPages.SurveysPage.KcAdd = "Добавить";
                    LangPages.SurveysPage.KcBack = "Назад";
                    LangPages.SurveysPage.KcChange = "Изменить";
                    LangPages.SurveysPage.KcDel = "Удалить";
                    LangPages.SurveysPage.TblListSurveys = "Список опросов";

                    #endregion

                    #region UsersPage

                    LangPages.UsersPage.CbxRoles = "Роль";
                    LangPages.UsersPage.DgNumber = "Номер";
                    LangPages.UsersPage.DgTime = "Время";
                    LangPages.UsersPage.DgTitle = "Название";
                    LangPages.UsersPage.KcAdd = "Добавить";
                    LangPages.UsersPage.KcBack = "Назад";
                    LangPages.UsersPage.KcChange = "Изменить";
                    LangPages.UsersPage.KcClear = "Очистить поле";
                    LangPages.UsersPage.KcDel = "Удалить";
                    LangPages.UsersPage.TblWorkers = "Сотрудники";
                    LangPages.UsersPage.TbxLogin = "Логин";
                    LangPages.UsersPage.TbxName = "Имя";
                    LangPages.UsersPage.TbxSurName = "Фамилия";


                    #endregion

                    #region QuestionPage

                    LangPages.QuestionPage.KcNext = "Следующий";

                    #endregion

                    #region UserPage

                    LangPages.UserPage.DgCategory = "Категория";
                    LangPages.UserPage.DgTime = "Время";
                    LangPages.UserPage.DgTitle = "Название";
                    LangPages.UserPage.KcAbsent = "Отсутствует";
                    LangPages.UserPage.KcBestResult = "Лучший результат";
                    LangPages.UserPage.KcExit = "Выход";
                    LangPages.UserPage.KcGoSurvey = "Пройти опрос";

                    #endregion

                    #region AuthPege

                    LangPages.AuthPage.KcEntre = "Войти";
                    LangPages.AuthPage.TblSingIn = "Вход в систему";
                    LangPages.AuthPage.TblLogin = "Логин";
                    LangPages.AuthPage.TblPassword = "Пароль";
                    LangPages.AuthPage.TblLanguage = "Язык";

                    #endregion

                    break;
                case Lang.ENG:

                    #region AdminPage

                    LangPages.AdminPage.DgCategory = "Category";
                    LangPages.AdminPage.DgName = "Name";
                    LangPages.AdminPage.DgRating = "Rating";
                    LangPages.AdminPage.DgStatiatic = "Statistic";
                    LangPages.AdminPage.DgSurvey = "Survey";
                    LangPages.AdminPage.DgTotal = "Total in %";
                    LangPages.AdminPage.DgSurName = "Surname";
                    LangPages.AdminPage.KcExit = "Exit";
                    LangPages.AdminPage.KcSurveys = "Surveys";
                    LangPages.AdminPage.KcWorkers = "Workers";
                    #endregion

                    #region CategoriesPage
                    LangPages.CategoriesPage.DgCatSurveys = "Surveys categories";
                    LangPages.CategoriesPage.KcChangeCat = "Change category";
                    LangPages.CategoriesPage.KcDelCat = "Delete category";
                    LangPages.CategoriesPage.KcExit = "Exit";
                    LangPages.CategoriesPage.KcLookSurveys = "Look Surveys";
                    LangPages.CategoriesPage.KcNewCat = "New category";
                    #endregion

                    #region SurveyPage

                    LangPages.SurveyPage.KcAdd = "Add";
                    LangPages.SurveyPage.KcBack = "ComeBack";
                    LangPages.SurveyPage.KcChange = "Change";
                    LangPages.SurveyPage.KcDel = "Delete";
                    LangPages.SurveyPage.TblQuestion = "Question";
                    LangPages.SurveyPage.TblQuestions = "Questions";
                    LangPages.SurveyPage.TblReports = "Reports";

                    #endregion

                    #region SurveysPage

                    LangPages.SurveysPage.DgNumber = "Number";
                    LangPages.SurveysPage.DgTime = "Time";
                    LangPages.SurveysPage.DgTitle = "Title";
                    LangPages.SurveysPage.KcAdd = "Add";
                    LangPages.SurveysPage.KcBack = "ComeBack";
                    LangPages.SurveysPage.KcChange = "Change";
                    LangPages.SurveysPage.KcDel = "Delete";
                    LangPages.SurveysPage.TblListSurveys = "List surveys";

                    #endregion

                    #region UsersPage

                    LangPages.UsersPage.CbxRoles = "Role";
                    LangPages.UsersPage.DgNumber = "Number";
                    LangPages.UsersPage.DgTime = "Time";
                    LangPages.UsersPage.DgTitle = "Title";
                    LangPages.UsersPage.KcAdd = "Add";
                    LangPages.UsersPage.KcBack = "ComeBack";
                    LangPages.UsersPage.KcChange = "Change";
                    LangPages.UsersPage.KcClear = "Clear the field";
                    LangPages.UsersPage.KcDel = "Delete";
                    LangPages.UsersPage.TblWorkers = "Workers";
                    LangPages.UsersPage.TbxLogin = "Login";
                    LangPages.UsersPage.TbxName = "Name";
                    LangPages.UsersPage.TbxSurName = "Surname";


                    #endregion

                    #region QuestionPage

                    LangPages.QuestionPage.KcNext = "Next";

                    #endregion

                    #region UserPage

                    LangPages.UserPage.DgCategory = "Category";
                    LangPages.UserPage.DgTime = "Time";
                    LangPages.UserPage.DgTitle = "Title";
                    LangPages.UserPage.KcAbsent = "Absent";
                    LangPages.UserPage.KcBestResult = "Best result";
                    LangPages.UserPage.KcExit = "Exit";
                    LangPages.UserPage.KcGoSurvey = "Go to survey";

                    #endregion

                    #region AuthPege

                    LangPages.AuthPage.KcEntre = "Enter";
                    LangPages.AuthPage.TblSingIn = "Sing in";
                    LangPages.AuthPage.TblLogin = "Login";
                    LangPages.AuthPage.TblPassword = "Password";
                    LangPages.AuthPage.TblLanguage = "Language";

                    #endregion

                    break;
                default:
                    break;
            }
        }
    }
}

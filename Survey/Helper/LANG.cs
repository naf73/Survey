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
        public static string l1 { get; private set; }
        public static string l2 { get; private set; }




        public static void ChangeLang(Lang lang)
        {
            switch (lang)
            {
                case Lang.RUS:
                    #region AdminPage

                    LangPages.AdminPage.DgCategory = "Категория";
                    LangPages.AdminPage.DgName = "Имя";
                    LangPages.AdminPage.DgRating = "Рейтинг";
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

                    break;
                default:
                    break;
            }
        }
    }
}

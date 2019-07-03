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
                    LangPages.CategoriesPage.KcChange = "Изменить";
                    LangPages.CategoriesPage.KcDel = "Удалить";
                    LangPages.CategoriesPage.KcBack = "Выход";
                    LangPages.CategoriesPage.KcExport = "Экспорт";
                    LangPages.CategoriesPage.KcImport = "Импрот";
                    LangPages.CategoriesPage.KcNew = "Новая категория";
                    LangPages.CategoriesPage.KcAdd = "Добавить";
                    LangPages.CategoriesPage.DgCatTests = "Категории тестов";

                    #endregion

                    #region SurveyPage

                    LangPages.SurveyPage.KcAdd = "Добавить";
                    LangPages.SurveyPage.KcBack = "Назад";
                    LangPages.SurveyPage.KcChange = "Изменить";
                    LangPages.SurveyPage.KcDel = "Удалить";
                    LangPages.SurveyPage.DgQuestion = "Вопрос";
                    LangPages.SurveyPage.TblListQuestSurvey = "Список вопросов опроса";
                    LangPages.SurveyPage.LAnswer = "Ответ:";
                    LangPages.SurveyPage.LNameSurvey = "Наименование опроса";
                    LangPages.SurveyPage.KcCreate = "Создать";
                    LangPages.SurveyPage.LText = "Текст";
                    LangPages.SurveyPage.LPictures = "Картинка";
                    LangPages.SurveyPage.KcAddPictures = "Добавить картинку";
                    LangPages.SurveyPage.KcPicturesRemove = "Убрать картинку";
                    LangPages.SurveyPage.LAnswers = "Ответы:";
                    LangPages.SurveyPage.KcClearFields = "Очистить поля";
                    LangPages.SurveyPage.LAnswer = "Ответ:";
                    LangPages.SurveyPage.DgAnswer = "Ответ";


                    #endregion

                    #region SurveysPage

                    LangPages.SurveysPage.DgTime = "Время, мин";
                    LangPages.SurveysPage.DgTitle = "Название";
                    LangPages.SurveysPage.KcAdd = "Добавить";
                    LangPages.SurveysPage.KcCreate = "Создать";
                    LangPages.SurveysPage.KcBack = "Назад";
                    LangPages.SurveysPage.KcChange = "Изменить";
                    LangPages.SurveysPage.KcDel = "Удалить";
                    LangPages.SurveysPage.TblListSurveys = "Список опросов";
                    LangPages.SurveysPage.LCatName = "Наименование категории";
                    LangPages.SurveysPage.KcExport = "Экспорт";
                    LangPages.SurveysPage.KcImport = "Импрот";

                    #endregion

                    #region UsersPage

                    LangPages.UsersPage.CbxRole = "Роль";
                    LangPages.UsersPage.DgLogin = "Логин";
                    LangPages.UsersPage.DgSurName = "Фамилия";
                    LangPages.UsersPage.DgName = "Имя";
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
                    LangPages.UserPage.KcBack = "Выход";
                    LangPages.UserPage.KcGoSurvey = "Пройти опрос";

                    #endregion

                    #region AuthPege

                    LangPages.AuthPage.KcEntre = "Войти";
                    LangPages.AuthPage.TblSingIn = "Вход в систему";
                    LangPages.AuthPage.TblLogin = "Логин";
                    LangPages.AuthPage.TblPassword = "Пароль";
                    LangPages.AuthPage.TblLanguage = "Язык";

                    #endregion

                    #region Message Box

                    LangPages.MBox.DelCat = "Удалить категорию?";
                    LangPages.MBox.SprcifyCat = "Необходимо указать категорию для удаления";
                    LangPages.MBox.Del = "Удалить";
                    LangPages.MBox.Creat = "Создать";
                    LangPages.MBox.Change = "Изменить";
                    LangPages.MBox.AddCatToSystem = "Категория добавлена в систему";
                    LangPages.MBox.CatChange = "Категория изменена";
                    LangPages.MBox.EmptyFieldNotAll = "Пусто поле не допускается";
                    LangPages.MBox.MustCreateCat = "Необходимо создать категорию";
                    LangPages.MBox.ChooseAnsw = "Выберите ответ";

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
                    LangPages.AdminPage.DgSurName = "Sur Name";
                    LangPages.AdminPage.KcExit = "Exit";
                    LangPages.AdminPage.KcSurveys = "Surveys";
                    LangPages.AdminPage.KcWorkers = "Workers";
                    #endregion

                    #region CategoriesPage
                    LangPages.CategoriesPage.DgCatSurveys = "Surveys categories";
                    LangPages.CategoriesPage.KcChange = "Change";
                    LangPages.CategoriesPage.KcDel = "Delete";
                    LangPages.CategoriesPage.KcBack = "Exit";
                    LangPages.CategoriesPage.KcExport = "Export";
                    LangPages.CategoriesPage.KcImport = "Import";
                    LangPages.CategoriesPage.KcNew = "New category";
                    LangPages.CategoriesPage.KcAdd = "Add";
                    LangPages.CategoriesPage.DgCatTests = "Test categories";
                    #endregion

                    #region SurveyPage

                    LangPages.SurveyPage.KcAdd = "Add";
                    LangPages.SurveyPage.KcBack = "ComeBack";
                    LangPages.SurveyPage.KcChange = "Change";
                    LangPages.SurveyPage.KcDel = "Delete";
                    LangPages.SurveyPage.DgQuestion = "Question";
                    LangPages.SurveyPage.TblListQuestSurvey = "List of survey questions";                    
                    LangPages.SurveyPage.LNameSurvey = "Survey Name";
                    LangPages.SurveyPage.KcCreate = "Create";
                    LangPages.SurveyPage.LText = "Text";
                    LangPages.SurveyPage.LPictures = "Pictures";
                    LangPages.SurveyPage.KcAddPictures = "Add picture";
                    LangPages.SurveyPage.KcPicturesRemove = "Remove picture";
                    LangPages.SurveyPage.LAnswers = "Answers:";
                    LangPages.SurveyPage.KcClearFields = "Clear fields";
                    LangPages.SurveyPage.LAnswer = "Answer:";
                    LangPages.SurveyPage.DgAnswer = "Answer";


                    #endregion

                    #region SurveysPage

                    LangPages.SurveysPage.DgTime = "Time, min";
                    LangPages.SurveysPage.DgTitle = "Title";
                    LangPages.SurveysPage.KcAdd = "Add";
                    LangPages.SurveysPage.KcCreate = "Create";
                    LangPages.SurveysPage.KcBack = "ComeBack";
                    LangPages.SurveysPage.KcChange = "Change";
                    LangPages.SurveysPage.KcDel = "Delete";
                    LangPages.SurveysPage.TblListSurveys = "List surveys";
                    LangPages.SurveysPage.LCatName = "Category Name";
                    LangPages.SurveysPage.KcExport = "Export";
                    LangPages.SurveysPage.KcImport = "Import";

                    #endregion

                    #region UsersPage

                    LangPages.UsersPage.CbxRole = "Role";
                    LangPages.UsersPage.DgLogin = "Login";
                    LangPages.UsersPage.DgSurName = "Sur Name";
                    LangPages.UsersPage.DgName = "Name";
                    LangPages.UsersPage.KcAdd = "Add";
                    LangPages.UsersPage.KcBack = "ComeBack";
                    LangPages.UsersPage.KcChange = "Change";
                    LangPages.UsersPage.KcClear = "Clear the field";
                    LangPages.UsersPage.KcDel = "Delete";
                    LangPages.UsersPage.TblWorkers = "Workers";
                    LangPages.UsersPage.TbxLogin = "Login";
                    LangPages.UsersPage.TbxName = "Name";
                    LangPages.UsersPage.TbxSurName = "Sur Name";


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
                    LangPages.UserPage.KcBack = "Exit";
                    LangPages.UserPage.KcGoSurvey = "Go to survey";

                    #endregion

                    #region AuthPege

                    LangPages.AuthPage.KcEntre = "Enter";
                    LangPages.AuthPage.TblSingIn = "Sing in";
                    LangPages.AuthPage.TblLogin = "Login";
                    LangPages.AuthPage.TblPassword = "Password";
                    LangPages.AuthPage.TblLanguage = "Language";

                    #endregion

                    #region Message Box

                    LangPages.MBox.DelCat = "Delete category?";
                    LangPages.MBox.SprcifyCat = "You must specify a category to delete";
                    LangPages.MBox.Del = "Delete";
                    LangPages.MBox.Creat = "Create";
                    LangPages.MBox.Change = "Change";
                    LangPages.MBox.AddCatToSystem = "Category added to system";
                    LangPages.MBox.CatChange = "Category changed";
                    LangPages.MBox.EmptyFieldNotAll = "Empty field is not allowed";
                    LangPages.MBox.MustCreateCat = "You must create a category";
                    LangPages.MBox.ChooseAnsw = "Choose answer";

                    #endregion

                    break;
                default:
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Helper
{
    public static class LangPages
    {
        public static class AdminPage
        {
            public static string DgSurName { get; set; }
            public static string DgName { get; set; }
            public static string DgRating { get; set; }
            public static string DgSurvey { get; set; }
            public static string DgCategory { get; set; }
            public static string DgTotal { get; set; }
            public static string DgStatiatic { get; set; }
            public static string KcWorkers { get; set; }
            public static string KcSurveys { get; set; }
            public static string KcExit { get; set; }
        }
        public static class CategoriesPage
        {
            public static string DgCatSurveys { get; set; }            
            public static string KcNewCat { get; set; }
            public static string KcChangeCat { get; set; }
            public static string KcDelCat { get; set; }
            public static string KcLookSurveys { get; set; }
            public static string KcExit { get; set; }
        }
        public static class SurveyPage
        {
            public static string TblQuestions { get; set; }
            //public static string LbTP { get; set; }
            //public static string LbTO { get; set; }
            //public static string LbTVP { get; set; }
            public static string TblQuestion { get; set; }
            //public static string TbxTTP { get; set; }
            public static string TblReports { get; set; }
            //public static string LbO1 { get; set; }
            //public static string LbO2 { get; set; }
            //public static string LbO3 { get; set; }
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
        }
        public static class SurveysPage
        {
            public static string TblListSurveys { get; set; }
            public static string DgNumber { get; set; }
            public static string DgTitle { get; set; }
            public static string DgTime { get; set; }          
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
        }
        public static class UsersPage
        {
            public static string TblWorkers { get; set; }
            public static string DgNumber { get; set; }
            public static string DgTitle { get; set; }
            public static string DgTime { get; set; }
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
            public static string KcClear { get; set; }
            public static string CbxRoles { get; set; }
            public static string TbxName { get; set; }
            public static string TbxSurName { get; set; }
            public static string TbxLogin { get; set; }
        }
        public static class QuestionPage
        {           
            public static string KcNext { get; set; }
        }
        public static class UserPage
        {         
            public static string DgCategory { get; set; }
            public static string DgTitle { get; set; }
            public static string DgTime { get; set; }
            public static string KcExit { get; set; }
            public static string KcGoSurvey { get; set; }
            public static string KcBestResult { get; set; }
            public static string KcAbsent { get; set; }        
          
        }

        public static class AuthPage
        {
            public static string TblLogin { get; set; }
            public static string TblPassword { get; set; }
            public static string TblSingIn { get; set; }
            public static string TblLanguage { get; set; }
            public static string KcEntre { get; set; }          

        }
    }
}

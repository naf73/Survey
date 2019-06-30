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
            public static string KcNew { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
            public static string KcExport { get; set; }
            public static string KcImport { get; set; }
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string DgCatTests { get; set; }
        }
        public static class SurveyPage
        {
            public static string KcCreate { get; set; }     
            public static string DgQuestion { get; set; }
            
            public static string TblListQuestSurvey { get; set; }                      
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
            public static string LNameSurvey { get; set; }
            public static string LText { get; set; }
            public static string LPictures { get; set; }
            public static string KcAddPictures { get; set; }
            public static string KcPicturesRemove { get; set; }
            public static string LAnswers { get; set; }
            public static string KcClearFields { get; set; }
            public static string LAnswer { get; set; }
            public static string DgAnswer { get; set; }
        }
        public static class SurveysPage
        {
            public static string TblListSurveys { get; set; }          
            public static string DgTitle { get; set; }
            public static string DgTime { get; set; }          
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
            public static string LCatName { get; set; }
            public static string KcCreate { get; set; }
            public static string KcExport { get; set; }
            public static string KcImport { get; set; }
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
            public static string KcBack { get; set; }
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

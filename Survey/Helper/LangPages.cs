﻿using System;
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
            public static string DgLogin { get; set; }
            public static string DgSurName { get; set; }
            public static string DgName { get; set; }
            public static string KcBack { get; set; }
            public static string KcAdd { get; set; }
            public static string KcChange { get; set; }
            public static string KcDel { get; set; }
            public static string KcClear { get; set; }
            public static string CbxRole { get; set; }
            public static string TbxName { get; set; }
            public static string TbxSurName { get; set; }
            public static string TbxLogin { get; set; }
            public static string btnGenerate { get; set; }
        }
        public static class QuestionPage
        {           
            public static string KcNext { get; set; }
            public static string KcFinish { get; set; }
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
        public static class MBox
        {
            public static string DelCat { get; set; }
            public static string SprcifyCat { get; set; }
            public static string Del { get; set; }
            public static string Creat { get; set; }
            public static string Change { get; set; }
            public static string AddCatToSystem { get; set; }
            public static string CatChange { get; set; }
            public static string EmptyFieldNotAll { get; set; }
            public static string MustCreateCat { get; set; }
            public static string ChooseAnsw { get; set; }
            public static string TimeEntryError { get; set; }
            public static string ErrorEnteringPollName { get; set; }
            public static string MissingCorrectAnswer { get; set; }
            public static string NeedToAddQuestionAnswers { get; set; }
            public static string NotAllFieldsInTheQuestionAreFilled { get; set; }
            public static string DelQuestion { get; set; }
            public static string DelQuestionSpecifyIt { get; set; }
            public static string NotAllFieldsInTheAnswerAreFilled { get; set; }
            public static string YouMustSpecifyTheAnswerToEdit { get; set; }
            public static string DelAnswer { get; set; }
            public static string YouMustSpecifyTheAnswerToRemove { get; set; }
            public static string YouMustSpecifyCategoryName { get; set; }
            public static string DelSurvey { get; set; }
            public static string YouMustSpecifySurveyToDelete { get; set; }
            public static string NotAllFieldsAreFilled { get; set; }
            public static string YouMustSelectRowTable { get; set; }
            public static string DelWorker { get; set; }
            public static string SysMast1Admin { get; set; }
            public static string ErrorLog { get; set; }
            public static string TestCompleted { get; set; }


        }
    }
}

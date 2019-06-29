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
            public static string DgLastName { get; private set; }
            public static string DgName { get; private set; }
            public static string DgRating { get; private set; }
            public static string DgTest { get; private set; }
            public static string DgCategory { get; private set; }
            public static string DgTotal { get; private set; }
            public static string DgStatiatic { get; private set; }
            public static string KcWorkers { get; private set; }
            public static string KcSurveys { get; private set; }
            public static string KcExit { get; private set; }


        }
        public static class CategoriesPage
        {
            public static string DgCatTests { get; private set; }            
            public static string KcNewCat { get; private set; }
            public static string KcChangeCat { get; private set; }
            public static string KcDelCat { get; private set; }
            public static string KcLookTests { get; private set; }
            public static string KcExit { get; private set; }



        }
    }
}

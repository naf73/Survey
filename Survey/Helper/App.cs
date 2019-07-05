using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Helper
{
    public class App
    {
        public App()
        {
            Source = "(localdb)\\MSSQLLocalDB";
            Catalog = "survey";
            User = string.Empty;
            Password = string.Empty;
        }

        public string Conn
        {
            get
            {
                if (string.IsNullOrEmpty(User) || string.IsNullOrEmpty(Password))
                {
                    return string.Format("metadata = res://*/Model.Survey.csdl|" +
                                                    "res://*/Model.Survey.ssdl|" +
                                                    "res://*/Model.Survey.msl;" +
                                                    "provider=System.Data.SqlClient;" +
                                                    "provider connection string=\"data source={0};" +
                                                                                      "initial catalog={1};" +
                                                                                      "integrated security=True;" +
                                                                                      "MultipleActiveResultSets=True;" +
                                                                                      "App=EntityFramework;\"",
                                         Source, Catalog);                   
                }
                else
                {
                    return string.Format("metadata=res://*/Model.Survey.csdl|res://*/Model.Survey.ssdl|res://*/Model.Survey.msl;provider=System.Data.SqlClient;provider connection string=\"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}\"",
                                         Source, Catalog, User, Password);
                }
            }
            private set { }
        }

        public string Version
        {
            get
            {
#if DEBUG
                return "DEBUG";
#else
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
#endif
            }
            private set { }
        }

        public string Source { get; set; }

        public string Catalog { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string GetVersionCore
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.FileVersion;
            }

            private set { }
        }
    }
}

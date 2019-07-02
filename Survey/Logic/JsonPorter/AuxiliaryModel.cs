using System.IO;
using System.Collections.Generic;
//using Survey.Logic.JsonPorter;

namespace Survey.Logic.JsonPorter
{


	public class ModelExportImport
	{
        public ModelExportImport(){}
		public ModelExportImport(string _category, List<auxSurvey> _surv)
		{
			this.category = _category;
			this.surveys = _surv;
		}
		public ModelExportImport(List<auxStuff> _stf)
		{
			this.stuffs = _stf;
		}
		//JsonType1
		public List<auxStuff> stuffs { get; set; }

		//JsonType2
		public string category { get; set; }
		public List<auxSurvey> surveys { get; set; }

		public static string CheckCorrectPath(string path)
		{
			
			/*
			Какие тут пиздатые методы есть!!!!!
			EndWith и StartWith !!
			Это даже не Contains, от которого я охреневал в первый раз!!
			*/

			if (!path.StartsWith("json\\"))
			{
				path = "json\\" + path;
			}

			//Вызываем до проверки на ".json", чтобы меньше было удалять с конца
			CheckDirectory(path);

			if (!path.EndsWith(".json"))
			{
				path += ".json";
			}
			return  path;
		}

		private static void CheckDirectory(string path)
		{
			/*
			 Вот тут как раз спрашивал про изменение переменных в методах
			 подумал, что если расковырять path, то он может поменяться 
			 и в оригинале
			*/
			path = path.Substring(0, path.LastIndexOf("\\"));

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}

    public class auxStuff//JsonType1
	{
        public auxStuff(){}
        public auxStuff(int _id, float _result)
        {
            this.id = _id;
            this.result = _result;
        }
        public int id { get; set; }
        public float result { get; set; }
    }

    public class auxSurvey//JsonType2
    {
        public auxSurvey(){}
        public auxSurvey(string surveyName, List<auxStuff> stuffs)
        {
            this.name_of_survey = surveyName;
            this.list_of_stuff = stuffs;
        }
        public string name_of_survey { get; set; }
        public List<auxStuff> list_of_stuff { get; set; }
    }
}
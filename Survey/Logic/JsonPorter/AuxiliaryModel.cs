using System;
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

		//public JsonExporter(){}
		public static string CheckCorrectPath(string path)
		{
			if (!path.Contains(".json"))
			{
				path += ".json";
			}
			if (!path.Contains("json\\"))
			{
				path = "json\\" + path;
			}
			return  path;
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
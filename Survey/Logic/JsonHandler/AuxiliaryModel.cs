using System;

namespace Survey.Logic.JsonHandler
{

    public class ModelForConvert
    {
        public ModelForConvert()
        {

        }
        public string category { get; set; }
        public List<ListOfSurvey> list_of_survey { get; set; }
        //public List<ListOfStuff> list_of_stuff { get; set; }
    }

    public class ListOfStuff//JsonType1
    {
        public ListOfStuff()
        {

        }
        public ListOfStuff(int _id, float _result)
        {
            this.id = _id;
            this.result = _result;
        }
        public int id { get; set; }
        public float result { get; set; }
    }

    public class ListOfSurvey//JsonType2
    {
        public ListOfSurvey()
        {

        }
        public ListOfSurvey(string surveyName, List<ListOfStuff> stuffs)
        {
            this.name_of_survey = surveyName;
            this.list_of_stuff = stuffs;
        }
        public string name_of_survey { get; set; }
        public List<ListOfStuff> list_of_stuff { get; set; }
    }
}
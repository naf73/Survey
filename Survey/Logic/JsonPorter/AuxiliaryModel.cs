using System;

namespace JsonHandler
{

    [DataContract]
    public class ListOfStuff//JsonType1
    {
        public ListOfStuff()
        {

        }
        [DataMember] public int id { get; set; }
        [DataMember] public string result { get; set; }
    }

    [DataContract]
    public class ListOfSurvey//JsonType2
    {
        public ListOfSurvey()
        {

        }
        [DataMember] public string name_of_survey { get; set; }
        [DataMember] public List<ListOfStuff> list_of_stuff { get; set; }
    }

    public class AuxiliaryModel
    {
        public AuxiliaryModel()
        {

        }
        public string category { get; set; }
        public List<ListOfSurvey> list_of_survey { get; set; }
        //public List<ListOfStuff> list_of_stuff { get; set; }
    }
}
using System;
using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using Survey.Logic.JsonHandler.AuxiliaryModel;
using Survey.Logic.JsonHandler.Newtonsoft.Json;
using Survey.Logic.JsonHandler.Newtonsoft.Json.Linq;

namespace Survey.Logic.JsonHandler
{
    public static class JsonExporter
    {
        public JsonExporter(){}


        public static void Export(ModelForConvert mfc, string fileName)
        {
            if (!fileName.Contains(".json"))
            {
                fileName += ".json";
            }
            string serialized = JsonConvert.SerializeObject(mfc);

            if(serialized.Length() > 1)//Дабы избежать непредвиденных ситуаций
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }
                File.WriteAllText(fileName, serialized, encoding.GetEncoding(1251));
            }
        }
        public static void Export(ModelForConvert mfc)
        {
            Export(mfc, "unnamed.json");
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

/*

Насяйника, не ругаися! Знаю, что комменты избыточны.
Я с С++ переехилъ в С#. Многое пока не просто:)
 
*/

namespace Survey.Logic.JsonPorter
{
    public static class JsonExporter
    {
        public static void Export(ModelExportImport mei, string fileName)
        {

			fileName = ModelExportImport.CheckCorrectPath(fileName);

            string serialized = JsonConvert.SerializeObject(mei);

            if(serialized.Length > 1)//Дабы избежать непредвиденных ситуаций
            {

				//Вопрос

                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                }
                File.WriteAllText(fileName, serialized, Encoding.GetEncoding(1251));

            }
        }
        public static void Export(ModelExportImport mei)
        {
            Export(mei, "unnamed.json");
			
        }
    }
}

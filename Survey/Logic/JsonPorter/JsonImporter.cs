using System;
using System.IO;
using Newtonsoft.Json;

namespace Survey.Logic.JsonPorter
{
    public static class JsonImporter
    {
        public static ModelExportImport Import(string path)
		{
			path = ModelExportImport.CheckCorrectPath(path);
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
			string serialized =
				File.ReadAllText(path, System.Text.Encoding.GetEncoding(1251));
			ModelExportImport mei =
				JsonConvert.DeserializeObject<ModelExportImport>(serialized);
			return mei;
		}
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survey.Logic.JsonPorter;

namespace UnitTestSurvey
{
    [TestClass]
    public class UnitTestJson
    {



		[TestMethod]
		public void ExportToJsonType1NoPath()
		{
			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(777, 77.7f));

			ModelExportImport model =
				new ModelExportImport(stuffs);

			JsonExporter.Export(model);
		}

		[TestMethod]
        public void ImportToJsonType1()
		{

			ModelExportImport model =
				JsonImporter.Import("json\\name1.json");

			if (model != null)
			{
				if (model.stuffs[0].id == model.stuffs[0].result) ;
			}
		}

		[TestMethod]
		public void ExportToJsonType1OnlyName()
		{
			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(777, 77.7f));

			ModelExportImport model =
				new ModelExportImport(stuffs);

			JsonExporter.Export(model, "name1");
		}

		[TestMethod]
		public void ExportToJsonType1CorrectName()
		{
			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(777, 77.7f));

			ModelExportImport model =
				new ModelExportImport(stuffs);

			JsonExporter.Export(model, "name2.json");
		}

		[TestMethod]
		public void ExportToJsonType1WrongName()
		{
			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(777, 77.7f));

			ModelExportImport model =
				new ModelExportImport(stuffs);

			JsonExporter.Export(model, "name3.jxon");
		}

		[TestMethod]
		public void ExportToJsonType1WithPath()
		{
			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(777, 77.7f));

			ModelExportImport model =
				new ModelExportImport(stuffs);

			JsonExporter.Export(model, "folder\\name4.json");
		}

		[TestMethod]
		public void ExportToJsonType2()
		{
			List<auxStuff> stuffs1 = new List<auxStuff>();
			stuffs1.Add(new auxStuff(777, 77.7f));

			List<auxStuff> stuffs = new List<auxStuff>();
			stuffs.Add(new auxStuff(1328, 36.7f));
			stuffs.Add(new auxStuff(1329, 16.5f));
			stuffs.Add(new auxStuff(1332, 25.0f));
			stuffs.Add(new auxStuff(1337, 94.4f));
			stuffs.Add(new auxStuff(1345, 46.9f));

			string category = "Политика";

			List<auxSurvey> survs = new List<auxSurvey>();
			survs.Add(new auxSurvey(category, stuffs1));
			survs.Add(new auxSurvey(category, stuffs));

			ModelExportImport model =
				new ModelExportImport(category, survs);

			JsonExporter.Export(model);
		}
	}
}

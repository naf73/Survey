using Survey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class SurveyCategoryController
    {
        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    db.SurveyCategories.Add(new SurveyCategory()
                    {
                        Name = name
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(int id, string name)
        {
            if (id == 0) throw new ArgumentException();
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    var category = db.SurveyCategories.FirstOrDefault(c => c.Id == id);
                    if(!(category is null))
                    {
                        category.Name = name;
                        db.Entry(category).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using Survey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class CategoryController
    {
        public List<Category> Get()
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    return db.Categories.Where(c => c.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    db.Categories.Add(new Category()
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
                    var category = db.Categories.FirstOrDefault(c => c.Id == id);
                    if (!(category is null))
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

        public void Remove(int id)
        {
            if (id == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Id == id);
                    if(!(category is null))
                    {
                        category.IsDeleted = true;
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

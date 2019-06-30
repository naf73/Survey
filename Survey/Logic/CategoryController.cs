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
        private Helper.App _app = null;

        public CategoryController()
        {
            _app = new Helper.App();
        }

        public CategoryController(Helper.App app)
        {
            _app = app;
        }

        public List<Category> Get()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Categories.Where(c => c.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Category GetById(int id)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Categories.FirstOrDefault(c => c.IsDeleted == false &&
                                                             c.Id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name)) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    db.Categories.Add(category);
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
                using (var db = new SurveyContext(_app.Conn))
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
                using (var db = new SurveyContext(_app.Conn))
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

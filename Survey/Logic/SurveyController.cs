using Survey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class SurveyController
    {
        public List<Model.Survey> Get(int categoryId)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    return db.Surveys.Where(s => s.CategoryId == s.CategoryId &&
                                                 s.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Model.Survey> GetByUserId(int userId)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    List<UserSurvey> userSurveys = db.UserSurveys.Include(s => s.Survey)
                                                                 .Where(u => u.UserId == userId &&
                                                                             u.IsPass == false).ToList();
                    List<Model.Survey> surveys = new List<Model.Survey>();
                    userSurveys.ForEach(d =>
                    {
                        surveys.Add(d.Survey);
                    });
                    return surveys;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Model.Survey survey)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    db.Surveys.Add(survey);
                    db.SaveChanges();
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
                    var survey = db.Surveys.FirstOrDefault(s => s.Id == id &&
                                                                s.IsDeleted == false);
                    if(!(survey is null))
                    {
                        survey.IsDeleted = true;
                        db.Entry(survey).State = EntityState.Modified;
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

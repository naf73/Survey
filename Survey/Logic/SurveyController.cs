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
        private Helper.App _app = null;

        public SurveyController()
        {
            _app = new Helper.App();
        }

        public SurveyController(Helper.App app)
        {
            _app = app;
        }

        public List<Model.Survey> Get(int categoryId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
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
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<UserSurvey> userSurveys = db.UserSurveys.Where(u => u.UserId == userId &&
                                                                             u.IsPass == false).ToList();
                    List<Model.Survey> surveys = new List<Model.Survey>();
                    userSurveys.ForEach(d =>
                    {
                        var survey = db.Surveys.Include(c => c.Category)
                                               .FirstOrDefault(s => s.Id == d.SurveyId);
                        if (!(survey is null)) surveys.Add(survey);
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
                using (var db = new SurveyContext(_app.Conn))
                {
                    db.Surveys.Add(survey);
                    db.SaveChanges();

                    // === Добавляем пользователей в опрос

                    JoinUsersToSurvey(survey.Id);
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

        public void JoinUsersToSurvey(int surveyId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<User> users = db.Users.Where(u => u.IsDeleted == false &&
                                                           u.IsAdmin == false).ToList();
                    var survey = db.Surveys.FirstOrDefault(s => s.IsDeleted == false &&
                                                                s.Id == surveyId);
                    if (!(survey is null) && users.Count > 0)
                    {
                        foreach (var user in users)
                        {
                            db.UserSurveys.Add(new UserSurvey()
                            {
                                SurveyId = surveyId,
                                UserId = user.Id,
                                IsPass = false,
                                Result = 0
                            });
                            db.SaveChanges();
                        }
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

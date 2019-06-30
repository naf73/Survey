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
                                               .Include(q => q.Question)
                                               .Include(qa => qa.Question.Select(a => a.Answer))
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

        public List<Model.Survey> GetByCategoryId(int categoryId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Surveys.Where(g => g.IsDeleted == false &&
                                                 g.CategoryId == categoryId).ToList();
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
                    if (!(survey is null))
                    {
                        survey.IsDeleted = true;
                        db.Entry(survey).State = EntityState.Modified;
                        db.SaveChanges();
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

        public void SetMark(int surveyId, int userId, double result)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    UserSurvey userSurvey = db.UserSurveys.FirstOrDefault(m => m.UserId == userId &&
                                                                              m.SurveyId == surveyId);
                    if(!(userSurvey is null))
                    {
                        userSurvey.IsPass = true;
                        userSurvey.Result = result;
                        db.Entry(userSurvey).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetTheBestSurveyOfUser(int userId)
        {
            if (userId == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<UserSurvey> surveys = db.UserSurveys.Include(w => w.Survey)
                                                             .Where(s => s.UserId == userId &&
                                                                         s.IsPass == true)
                                                             .ToList();
                    if (surveys != null && surveys.Count > 0)
                    {
                        surveys.OrderByDescending(x => x.Result).ToList();
                        return string.Format("{0} {1} %", surveys[0].Survey.Name, surveys[0].Result);
                    }
                    else
                    {
                        return string.Empty;
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

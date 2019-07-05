using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class StatisticsController
    {
        private Helper.App _app = null;

        public StatisticsController()
        {
            _app = new Helper.App();
        }

        public StatisticsController(Helper.App app)
        {
            _app = app;
        }

        public List<StatEmployee> GetStatEmployees()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<StatEmployee> statEmployees = new List<StatEmployee>();
                    List<User> users = db.Users.Where(a => a.IsAdmin == false &&
                                                           a.IsDeleted == false)
                                               .ToList();
                    users.ForEach(u =>
                    {
                        double result = u.UserSurvey.Count(c => c.UserId == u.Id) > 0 ?
                                        u.UserSurvey.Where(d => d.UserId == u.Id)
                                                         .ToList()
                                                         .Sum(item => item.Result) /
                                             u.UserSurvey.Where(s => s.UserId == u.Id)
                                                         .Count() / 100 : 0;
                        statEmployees.Add(new StatEmployee()
                        {
                            Id = u.Id,
                            Surname = u.Surname,
                            Name = u.Name,
                            RatingEmployee = result
                        });
                    });
                    return statEmployees;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StatSurvey> GetStatSurveys(int userId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<StatSurvey> statSurveys = new List<StatSurvey>();
                    List<UserSurvey> surveys = db.UserSurveys.Where(s => s.UserId == userId &&
                                                                         s.IsPass == true)
                                                             .ToList();

                    surveys.ForEach(s =>
                    {
                        statSurveys.Add(new StatSurvey()
                        {
                            Survey = s.Survey.Name,
                            RatingSurvey = s.Result / 100,
                            Catalog = s.Survey.Category.Name
                        });
                    });

                    return statSurveys;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class StatEmployee
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public double RatingEmployee { get; set; }
    }

    public class StatSurvey
    {
        public string Survey { get; set; }

        public string Catalog { get; set; }

        public double RatingSurvey { get; set; }
    }
}

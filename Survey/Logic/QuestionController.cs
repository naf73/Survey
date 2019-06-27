using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class QuestionController
    {
        public List<Question> Get(int surveyId)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    return db.Questions
                             .Include(a => a.Answer)
                             .Where(q => q.SurveyId == surveyId &&
                                         q.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Question question, List<Answer> answers)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Questions.Add(question);

                            foreach (var answer in answers)
                            {
                                answer.QuestionId = question.Id;
                                db.Answers.Add(answer);
                            }

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
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

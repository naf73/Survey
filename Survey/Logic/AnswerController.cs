using Survey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class AnswerController
    {
        public List<Answer> GetAnswersByQuestion(int questionId)
        {
            try
            {
                using (var db = new SurveyContext())
                {
                    return db.Answers.Where(q => q.QuestionId == questionId &&
                                                 q.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public  void AddAnswersToQuestion(int questionId, List<Answer> answers)
        {
            if (questionId == 0) throw new ArgumentException();
            if (answers == null) throw new ArgumentNullException();
            if (answers.Count == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    answers.ForEach(a =>
                    {
                        db.Answers.Add(a);
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveAnswerFromQuestion(int questionId, List<Answer> answers)
        {
            if (questionId == 0) throw new ArgumentException();
            if (answers == null) throw new ArgumentNullException();
            if (answers.Count == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext())
                {
                    answers.ForEach(a =>
                    {
                        var answer = db.Answers.FirstOrDefault(ca => ca.Id == a.Id);
                        if (!(answer is null))
                        {
                            answer.IsDeleted = true;
                            db.Entry(answer).State = EntityState.Modified;
                        }
                    });
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

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
        private Helper.App _app = null;

        #region Constructors

        public QuestionController()
        {
            _app = new Helper.App();
        }

        public QuestionController(Helper.App app)
        {
            _app = app;
        }

        #endregion

        public List<Question> Get(int surveyId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
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
            if (question == null) throw new ArgumentNullException();
            if (answers == null) throw new ArgumentNullException();
            if (answers.Count == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
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

        public void Edit(Question question, List<Answer> answers)
        {
            if (question == null) throw new ArgumentNullException();
            if (question.Id == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    db.Entry(question).State = EntityState.Modified;

                    List<Answer> questionAnswers = db.Answers.Where(a => a.IsDeleted == false &&
                                                                         a.QuestionId == question.Id).ToList();
                    List<Answer> newAnswer = new List<Answer>();
                    List<Answer> existAnswers = new List<Answer>();

                    if(questionAnswers != null && questionAnswers.Count > 0)
                    {
                        foreach (var answer in answers)
                        {
                            if(answer.Id == 0)
                            {
                                answer.QuestionId = question.Id;
                                newAnswer.Add(answer);
                            }
                            else
                            {
                                Answer questionAnswer = questionAnswers.FirstOrDefault(q => q.Id == answer.Id);
                                if(questionAnswer != null)
                                {
                                    questionAnswer.Text = answer.Text;
                                    questionAnswer.Foto = answer.Foto;
                                    questionAnswer.IsTrue = answer.IsTrue;
                                    db.Entry(questionAnswer).State = EntityState.Modified;
                                    existAnswers.Add(questionAnswer);
                                }
                            }
                        }
                    }

                    foreach (var answer in newAnswer)
                    {
                        db.Answers.Add(answer);
                    }

                    foreach (var answer in questionAnswers)
                    {
                        if(existAnswers.FirstOrDefault(q => q.Id == answer.Id) == null)
                        {
                            answer.IsDeleted = true;
                            db.Entry(question).State = EntityState.Modified;
                        }
                    }
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
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    Question question = db.Questions.FirstOrDefault(q => q.IsDeleted == false &&
                                                                         q.Id == id);
                    if(!(question is null))
                    {
                        question.IsDeleted = true;
                        db.Entry(question).State = EntityState.Modified;
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

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
        public List<Answer> Get(int questionId)
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
    }
}

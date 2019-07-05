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
        private Helper.App _app = null;

        public AnswerController()
        {
            _app = new Helper.App();
        }

        public AnswerController(Helper.App app)
        {
            _app = app;
        }

        public List<Answer> Get(int questionId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
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

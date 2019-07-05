using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survey.Helper;
using Survey.Logic;
using Survey.Model;

namespace UnitTestSurvey
{
    [TestClass]
    public class UnitTestDB
    {
        private CategoryController categoryController = new CategoryController();
        private SurveyController surveyController = new SurveyController();
        private UserController userController = new UserController();

        [TestMethod]
        public void InitDB()
        {
            if (userController.Get().Count == 0)
            {
                userController.AddAdmin();                
                categoryController.Add(new Category() { Name = "Техника безопасности" });
                categoryController.Add(new Category() { Name = "Техника пожарной безопасности" });

                Category category = categoryController.Get()[0];

                for (int k = 0; k < 3; k++)
                {
                    List<Question> questions = new List<Question>();                    

                    for (int i = 0; i < 10; i++)
                    {
                        List<Answer> answers = new List<Answer>();
                        for (int j = 0; j < 3; j++)
                        {
                            if (j == 0)
                            {
                                answers.Add(new Answer()
                                {
                                    Text = string.Format("{0} {1}", j, RandomString(23)),
                                    IsTrue = true,
                                    IsDeleted = false
                                });
                            }
                            else
                            {
                                answers.Add(new Answer()
                                {
                                    Text = string.Format("{0} {1}", j, RandomString(23)),
                                    IsTrue = false,
                                    IsDeleted = false
                                });
                            }
                        }
                        questions.Add(new Question()
                        {
                            Text = string.Format("{0} {1} ", i, RandomString(34)),
                            Answer = answers,
                            IsDeleted = false,
                            Foto = ConvertPicture.BitmapImageToByteArray(new BitmapImage(new Uri(@"C:\Users\User\source\repos\naf73\Survey\Survey\Pictures\Hamster.jpg", UriKind.Relative)))
                        });
                    }

                    surveyController.Add(new Survey.Model.Survey()
                    {
                        Name = string.Format("{0} {1}", k, RandomString(25)),
                        CategoryId = category.Id,
                        Time = 1,
                        Question = questions
                    });
                }
            }



        }

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        private int RandomNum(int max, int min = 0)
        {
            Random random = new Random(4342425);
            return random.Next(min, max);
        }

    }
}

using Survey.Exceptions;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Logic
{
    public class UserController
    {
        private Helper.App _app = null;

        public UserController()
        {
            _app = new Helper.App();
        }

        public UserController(Helper.App app)
        {
            _app = app;
        }

        /// <summary>
        /// Выводит всех пользователей, кроме администратора и удаленных
        /// </summary>
        /// <returns></returns>
        public List<User> Get()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Users.Where(u => u.IsDeleted == false &&
                                               u.IsAdmin == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Выводит всех активных пользователей системе, в том числе администратора
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Users.Where(u => u.IsDeleted == false).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetAdminCount()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Users.Count(u => u.IsAdmin == true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetById(int id)
        {
            if (id == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Users.FirstOrDefault(u => u.IsDeleted == false &&
                                                        u.IsAdmin == false &&
                                                        u.Id == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(User user)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    if (ExistsUserByLogin(user.Id, user.Login)) throw new UserExistsException();

                    db.Users.Add(user);
                    db.SaveChanges();

                    // === Добавляем опросы для нового пользователя

                    JoinSurveysToUser(user.Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(User user)
        {
            if (user == null) throw new ArgumentNullException();
            if (user.Id == 0) throw new ArgumentException();
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    if (ExistsUserByLogin(user.Id, user.Login)) throw new UserExistsException();

                    db.Entry(user).State = EntityState.Modified;
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
                using (var db = new SurveyContext(_app.Conn))
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == id &&
                                                            u.IsDeleted == false);
                    if(!(user is null))
                    {
                        user.IsDeleted = true;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }  
        
        public User GetUserByPass(string login, string password)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    return db.Users.FirstOrDefault(u => u.IsDeleted == false &&
                                                        u.Login == login &&
                                                        u.Password == password);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddAdmin()
        {
            try
            {
                if(!ExistAdmin())
                {
                    Add(new User()
                    {
                        Login = "admin",
                        Password = "admin",
                        Name = string.Empty,
                        Surname = string.Empty,
                        IsAdmin = true
                    });

                    // add test user

                    Add(new User()
                    {
                        Login = "user",
                        Password = "user",
                        Name = "Иван",
                        Surname = "Иванов",
                        IsAdmin = false
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ExistAdmin()
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    var user = db.Users.FirstOrDefault(u => u.IsAdmin == true);
                    if (user is null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void JoinSurveysToUser(int userId)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    List<Model.Survey> surveys = db.Surveys.Where(s => s.IsDeleted == false).ToList();
                    
                    foreach(var survey in surveys)
                    {
                        db.UserSurveys.Add(new UserSurvey()
                        {
                            UserId = userId,
                            SurveyId = survey.Id,
                            IsPass = false,
                            Result = 0
                        });
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ExistsUserByLogin(int id, string login)
        {
            try
            {
                using (var db = new SurveyContext(_app.Conn))
                {
                    User user = db.Users.FirstOrDefault(u => u.IsDeleted == false &&
                                                             u.Login == login);
                    if (id != 0)
                        if (!(user is null) && id == user.Id) return false;
                    return !(user is null);
                }             
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

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
                    db.Users.Add(user);
                    db.SaveChanges();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab_2_web_design.Models;
using System.Data.Entity;

namespace lab_2_web_design.Data
{
    public class EfRepository: IRepository
    {
        private readonly DataContext _dataContext = new DataContext();

        public void addUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public void addYarn(Yarn yarn)
        {
            foreach(var user in yarn.Users)
            {
                _dataContext.Users.Attach(user);
            }
            _dataContext.Yarn.Add(yarn);
            _dataContext.SaveChanges();
        }
        public bool doesUserHaveYarn(User user)
        {
            int yarnCount = _dataContext.Entry(user)
                          .Collection(userId => userId.Yarns)
                          .Query()
                          .Count();
            return yarnCount>0;
        }

        public List<User> GetAllUsers()
        {
            return _dataContext.Users.ToList();
        }

        public List<Yarn> GetAllYarn()
        {
            return _dataContext.Yarn.ToList();
        }

        public User getUser(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public Yarn getYarn(int id)
        {
            return _dataContext.Yarn.Find(id);
        }

        public void removeUser(User id)
        {
            _dataContext.Users.Remove(id);
            _dataContext.SaveChanges();
        }

        public void removeYarn(Yarn id)
        {
            _dataContext.Yarn.Remove(id);
            _dataContext.SaveChanges();
        }

        public void updateUser(User id)
        {
            _dataContext.Entry(id).State = EntityState.Modified;
            _dataContext.SaveChanges(); 
        }

        public void updateYarn(Yarn id)
        {
            _dataContext.Entry(id).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}
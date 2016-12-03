using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab_2_web_design.Models;
using lab_2_web_design.Data;

namespace lab_2_web_design.Services
{
    public class UserService : IUser
    {
        IRepository _dataContext;

        public UserService(IRepository dataContext)
        {
            _dataContext = dataContext;
        }
        public bool UserhasYarn(User user)
        {
            //if users.Yarns is not equal to null AND blah balh
            return _dataContext.doesUserHaveYarn(user);
        }
    }
}
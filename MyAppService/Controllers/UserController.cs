using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using lab_2_web_design.Models;

namespace MyAppService.Controllers
{
    public class UserController : ApiController
    {
        public class UsersController : ApiController
        {
            User[] Users = new User[]
            {
            new User { FirstName = "Bake", LastName = "Bread", EmailAdress = "BB@site.com", UserId=1},
            new User { FirstName = "Tank", LastName = "The Dog", EmailAdress = "Tank@site.com", UserId=2},
            };

            public IEnumerable<User> GetAllUsers()
            {
                return Users;
            }

            public IHttpActionResult Get(int id)
            {
                var User = Users.FirstOrDefault((p) => p.UserId == id);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
            }
        }
    }
}

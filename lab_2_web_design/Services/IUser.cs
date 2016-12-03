using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab_2_web_design.Models;

namespace lab_2_web_design.Services
{
    public interface IUser
    {
        bool UserhasYarn(User user);
    }
}
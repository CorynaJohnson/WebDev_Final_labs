using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_2_web_design.Models;

namespace lab_2_web_design.Data
{
    public interface IRepository
    {
        List<User> GetAllUsers();
        void addUser(User user);
        User getUser(int id);
        void updateUser(User id);
        void removeUser(User id);
        List<Yarn> GetAllYarn();
        void addYarn(Yarn yarn);
        Yarn getYarn(int id);
        void updateYarn(Yarn id);
        void removeYarn(Yarn id);
        bool doesUserHaveYarn(User user);
    }
}

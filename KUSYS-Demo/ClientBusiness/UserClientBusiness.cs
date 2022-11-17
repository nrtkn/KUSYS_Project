using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace KUSYS_Demo.ClientBusiness
{
    public class UserClientBusiness
    {
        UserManager userManager = new UserManager(new EFUserDAL());
        public User ControlLogin(User user)
        {
            User usr = new User();
            var userList = userManager.GetUsers().Data;
            usr = userList.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            return usr;
        }
    }
}

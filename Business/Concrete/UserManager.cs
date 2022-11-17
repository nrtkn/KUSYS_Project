using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IDataResult<User> GetUser(string userName, string pw)
        {
            return new SuccessDataResult<User>(_userDAL.Get(x=>x.UserName == userName && x.Password == pw));
        }

        public IDataResult<List<User>> GetUsers()
        {
            var list = _userDAL.GetAll();
            return new SuccessDataResult<List<User>>(list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Context;
using Business.Dto;
using Common.Models;
using System.Data.Entity;

namespace Business.Engine
{
    public class UserEngine : IUserEngine
    {
        private readonly UserContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserEngine(IUnitOfWork unitOfWork, UserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> users = new List<UserDto>();
            var t = _userContext.Users.ToList();
            var t2 = _unitOfWork.Users.GetAll();
            return users;
        }

        public UserAccounts Add(UserAccounts user)
        {
            var db = new UserContext();
            var newUser = db.Users.Add(user);
            db.Entry(newUser).State = EntityState.Added;
            db.SaveChanges();
            return newUser;
        }
    }

    public interface IUserEngine
    {
        List<UserDto> GetAll();
        UserAccounts Add(UserAccounts user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Context;
using Business.Dto;
using Common.Models;

namespace Business.Engine
{
    public class UserEngine
    {
        private readonly UserContext _userContext;

        public UserEngine()
        {
            UserContext userContext = new UserContext();
            _userContext = userContext;
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> users = new List<UserDto>();
            var t = _userContext.Users.ToList();
            var db = new UserContext();
            return users;
        }

        public User Add(User user)
        {
            var db = new UserContext();
            var newUser = db.Users.Add(user);
            db.SaveChanges();
            return newUser;
        }
    }

    public interface IUserEngine
    {
        List<UserDto> GetAll();
        User Add(User user);
    }
}

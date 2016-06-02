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
        private readonly Context.BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserEngine(IUnitOfWork unitOfWork, BusinessContext userContext)
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

        public ServiceResult Add(UserAccounts user)
        {
            var result = new ServiceResult();
            result.IsSuccess = true;
            //here we need to make sure username and email are unique
            var db = new BusinessContext();
            var checkEmail = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            var checkUsername = db.Users.Where(u => u.Username == user.Username).FirstOrDefault();

            if (checkEmail != null)
            {
                result.IsSuccess = false;
                result.Error = "Email already exists";
                return result;
            }

            if (checkUsername != null)
            {
                result.IsSuccess = false;
                result.Error = "Username already exists";
                return result;
            }

            var newUser = db.Users.Add(user);
            db.Entry(newUser).State = EntityState.Added;
            db.SaveChanges();
            result.ReturnObject = newUser;
            result.Error = $"{user.Email} successfully registered!";
            return result;
        }
    }

    public interface IUserEngine
    {
        List<UserDto> GetAll();
        ServiceResult Add(UserAccounts user);
    }
}

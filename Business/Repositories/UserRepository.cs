using Business.Context;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Business.Repositories;

namespace Business.Repositories
{
    public class UserRepository : Repository<UserAccounts>, IUserRepository
    {
        public UserRepository(UserContext context) 
            : base(context)
        {

        }

        public IEnumerable<UserAccounts> GetByName(string name)
        {
            return UserContext.Users.Where(u => u.Username.Contains(name)).ToList();
        }

        public UserContext UserContext
        {
            get { return Context as UserContext; }
        }
    }

    public interface IUserRepository : IRepository<UserAccounts>
    {
        IEnumerable<UserAccounts> GetByName(string name);
    }


}

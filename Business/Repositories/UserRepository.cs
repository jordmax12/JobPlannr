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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserContext context) 
            : base(context)
        {

        }

        public IEnumerable<User> GetByName(string name)
        {
            return UserContext.Users.Where(u => u.username.Contains(name)).ToList();
        }

        public UserContext UserContext
        {
            get { return Context as UserContext; }
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByName(string name);
    }


}

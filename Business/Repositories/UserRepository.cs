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
        public UserRepository(BusinessContext context) 
            : base(context)
        {

        }

        public IEnumerable<User> GetByName(string name)
        {
            return BusinessContext.Users.Where(u => u.Username.Contains(name)).ToList();
        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByName(string name);
    }


}

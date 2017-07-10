using Business.Context;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class HelperRepository : Repository<Helper>, IHelperRepository
    {
        public HelperRepository(BusinessContext context)
            : base(context)
        {

        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }

        public IQueryable<Helper> GetAllDash(int userId)
        {
            return BusinessContext.Helpers.Where(h => h.UserId == userId);
        }

        public IQueryable<Helper> GetAllEntry(int userId, int entryId)
        {
            return BusinessContext.Helpers.Where(h => h.UserId == userId && h.EntryId == entryId);
        }
    }


    public interface IHelperRepository : IRepository<Helper>
    {
        IQueryable<Helper> GetAllDash(int id);
        IQueryable<Helper> GetAllEntry(int id, int entryId);
    }
}

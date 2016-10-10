using Business.Context;
using Business.Repositories;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public EntryRepository(BusinessContext context)
            : base(context)
        {

        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }

        public List<Entry> GetAll(int id)
        {
            return BusinessContext.Entries.Where(e => e.Id == id).ToList();
        }
    }

    public interface IEntryRepository
    {
        List<Entry> GetAll(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Context;
using Business.Repositories;
using Common.Models;

namespace Business.Repositories
{
    public class ContributorRepository : Repository<Contributor>, IContributorRepository
    {
        public ContributorRepository(BusinessContext context)
            : base(context)
        {

        }

        public Contributor Update(Contributor contributor)
        {
            throw new NotImplementedException();
        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }

        public List<Contributor> GetAll(int id)
        {
            return BusinessContext.Contributors.Where(c => c.Id == id).ToList();
        }
    }

    public interface IContributorRepository
    {
        Contributor Update(Contributor contributor);
        List<Contributor> GetAll(int id);
    }
}
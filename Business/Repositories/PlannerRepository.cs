using Business.Context;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class PlannerRepository : Repository<Planner>, IPlannerRepository
    {
        public PlannerRepository(BusinessContext context)
            : base(context)
        {

        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }

        public List<Planner> GetAll(int id)
        {
            return BusinessContext.Planner.Where(p => p.UserId == id).ToList();
        }
    }

    public interface IPlannerRepository : IRepository<Planner>
    {
        List<Planner> GetAll(int id);
    }


}

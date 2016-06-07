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

        public Planner Update(Planner planner)
        {
            throw new NotImplementedException();
        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }
    }

    public interface IPlannerRepository : IRepository<Planner>
    {
        Planner Update(Planner planner);
    }


}

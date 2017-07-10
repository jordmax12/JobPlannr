using Business.Context;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class SubTaskRepository : Repository<SubTask>, ISubTaskRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubTaskRepository(BusinessContext context, IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Common.Models.SubTask> GetAll(int id)
        {
            return BusinessContext.SubTasks.Where(s => s.TaskId == id).ToList();
        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }
    }

    public interface ISubTaskRepository : IRepository<SubTask>
    {
        List<Common.Models.SubTask> GetAll(int id);
    }
}

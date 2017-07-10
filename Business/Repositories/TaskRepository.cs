using Business.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class TaskRepository : Repository<Common.Models.Task>, ITaskRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskRepository(BusinessContext context, IUnitOfWork unitOfWork)
            : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        //public Common.Models.Task Update(Common.Models.Task task)
        //{
        //    var _task = BusinessContext.Tasks.Where(t => t.Id == task.Id).FirstOrDefault();
        //    if(_task != null)
        //    {
        //        _task.Modified = DateTime.Now;
                
        //        return _task;
        //    } else
        //    {
        //        return _task;
        //    }
        //}

        public List<Common.Models.Task> GetAll(int id)
        {
            return BusinessContext.Tasks.Where(t => t.PlannerId == id).OrderBy(t => t.Created).Include(t => t.SubTasks).ToList();
        }

        public BusinessContext BusinessContext
        {
            get { return Context as BusinessContext; }
        }
    }

    public interface ITaskRepository : IRepository<Common.Models.Task>
    {

        //Common.Models.Task Update(Common.Models.Task task);

        List<Common.Models.Task> GetAll(int id);
    }
}

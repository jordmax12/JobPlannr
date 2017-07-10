using System;
using System.Collections.Generic;
using System.Linq;
using Business.Context;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories;
using Business.Dto;

namespace Business.Engine
{
    public class TaskEngine : ITaskEngine
    {
        private readonly Context.BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;

        public TaskEngine(IUnitOfWork unitOfWork, BusinessContext userContext, ITaskRepository taskRepository)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _taskRepository = taskRepository;
        }

        public ServiceResult Update(Common.Models.Task task)
        {
            ServiceResult result = new ServiceResult();

            task.Modified = DateTime.Now;
            _taskRepository.Update(task);
            //var _task = _taskRepository.A
            //if(_task == null)
            //{
            //    result.IsSuccess = false;
            //    result.Error = "ERR: 001 - Could not find task to update.";
            //    return result;
            //}

            //result.ReturnObject = _task;
            result.IsSuccess = true;

            return result;
        }

        public void Delete(Common.Models.Task task)
        {
            _taskRepository.Remove(task);
        }

        public void Add(Common.Models.Task task)
        {
            _taskRepository.Add(task);
        }

        public Common.Models.Task AddWithReturn(Common.Models.Task task)
        {
            return _taskRepository.AddWithReturn(task);
        }

        public Common.Models.Task Get(int id)
        {
            return _taskRepository.Get(id);
        }

        public List<Common.Models.Task> GetAll(int id)
        {
            return _taskRepository.GetAll(id);
        }

        //public List<Task> GetAll(int id)
        //{
        //    return _taskRepository.GetAll(id);
        //}
    }

    public interface ITaskEngine
    {
        Common.Models.Task Get(int id);
        List<Common.Models.Task> GetAll(int id);
        ServiceResult Update(Common.Models.Task task);
        void Add(Common.Models.Task task);
        Common.Models.Task AddWithReturn(Common.Models.Task task);
        void Delete(Common.Models.Task task);
    }
}

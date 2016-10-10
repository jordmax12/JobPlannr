using Business.Context;
using Business.Dto;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine
{
    

    public class SubTaskEngine : ISubTaskEngine
    {

        private readonly BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubTaskRepository _subTaskRepository;

        public SubTaskEngine(IUnitOfWork unitOfWork, BusinessContext userContext, ISubTaskRepository subTaskRepository)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _subTaskRepository = subTaskRepository;
        }

        public ServiceResult Update(Common.Models.SubTask subTask)
        {
            ServiceResult result = new ServiceResult();

            subTask.Modified = DateTime.Now;
            _subTaskRepository.Update(subTask);
            result.IsSuccess = true;

            return result;
        }

        public void Delete(Common.Models.SubTask subTask)
        {
            _subTaskRepository.Remove(subTask);
        }

        public void Add(Common.Models.SubTask subTask)
        {
            _subTaskRepository.Add(subTask);
        }

        public Common.Models.SubTask AddWithReturn(Common.Models.SubTask subTask)
        {
           return _subTaskRepository.AddWithReturn(subTask);
        }

        public Common.Models.SubTask Get(int id)
        {
            return _subTaskRepository.Get(id);
        }

        public List<Common.Models.SubTask> GetAll(int id)
        {
            return _subTaskRepository.GetAll(id);
        }

    }

    public interface ISubTaskEngine
    {
        Common.Models.SubTask Get(int id);
        List<Common.Models.SubTask> GetAll(int id);
        ServiceResult Update(Common.Models.SubTask task);
        Common.Models.SubTask AddWithReturn(Common.Models.SubTask subTask);
        void Add(Common.Models.SubTask task);
        void Delete(Common.Models.SubTask task);
    }
}

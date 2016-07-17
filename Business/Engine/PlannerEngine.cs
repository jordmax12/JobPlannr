using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Context;
using Business.Dto;
using Common.Models;
using System.Data.Entity;
using Business.Repositories;

namespace Business.Engine
{
    public class PlannerEngine : IPlannerEngine
    {
        private readonly Context.BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlannerRepository _plannerRepository;

        public PlannerEngine(IUnitOfWork unitOfWork, BusinessContext userContext, IPlannerRepository plannerRepository)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _plannerRepository = plannerRepository;
        }

        public Planner Update(Planner planner)
        {
            return _plannerRepository.Update(planner);
        }

        public void Delete(Planner planner)
        {
            _plannerRepository.Remove(planner);
        }

        public void Add(Planner planner)
        {
            _plannerRepository.Add(planner);
        }

        public Planner Get(int id)
        {
            return _plannerRepository.Get(id);
        }

        public List<Planner> GetAll(int id)
        {
            return _plannerRepository.GetAll(id);
        }
    }

    public interface IPlannerEngine
    {
        Planner Get(int id);
        List<Planner> GetAll(int id);
        Planner Update(Planner planner);
        void Add(Planner planner);
        void Delete(Planner planner);
    }
}

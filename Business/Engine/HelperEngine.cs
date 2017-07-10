using Business.Context;
using Business.Repositories;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine
{
    public enum queryType : int
    {
        Name = 1,
        Company = 2
    }

    public class HelperEngine : IHelperEngine
    {
        private readonly Context.BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHelperRepository _helperRepository;

        public HelperEngine(IUnitOfWork unitOfWork, BusinessContext userContext, IHelperRepository helperRepository)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
            _helperRepository = helperRepository;
        }

        public Helper Get(int id)
        {
            return _helperRepository.Get(id);
        }

        public List<Helper> GetAllDash(int userId)
        {
            return _helperRepository.GetAllDash(userId).ToList();
        }

        public List<Helper> GetAllEntry(int userId, int entryId)
        {
            return _helperRepository.GetAllEntry(userId, entryId).ToList();
        }

        public List<Helper> Search(string query, queryType queryType)
        {
            throw new NotImplementedException();
        }

        public void Add(Helper helper)
        {
            _helperRepository.Add(helper);
        }

        public void Delete(Helper helper)
        {
            _helperRepository.Remove(helper);
        }
    }

    public interface IHelperEngine
    {
        Helper Get(int id);
        List<Helper> GetAllDash(int userId);
        List<Helper> GetAllEntry(int userId, int entryId );
        List<Helper> Search(string query, queryType queryType);
        void Add(Helper helper);
        void Delete(Helper helper);
    }
}

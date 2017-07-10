using Business.Context;
using Business.Dto;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Engine
{

    public class SubscriptionEngine : ISubscriptionEngine
    {
        private readonly BusinessContext _userContext;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionEngine(IUnitOfWork unitOfWork, BusinessContext userContext)
        {
            _unitOfWork = unitOfWork;
            _userContext = userContext;
        }

        public List<SubscriptionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmailSubscription Add(EmailSubscription user)
        {
            var db = new BusinessContext();
            var newUser = db.EmailSubscriptions.Add(user);
            db.Entry(newUser).State = EntityState.Added;
            db.SaveChanges();
            return newUser;
        }

    }

    public interface ISubscriptionEngine
    {
        List<SubscriptionDto> GetAll();
        EmailSubscription Add(EmailSubscription user);
    }
}

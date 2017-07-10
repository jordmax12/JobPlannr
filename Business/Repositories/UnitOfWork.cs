using Business.Context;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BusinessContext _context;

        public UnitOfWork(BusinessContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Tasks = new TaskRepository(_context, this);
            SubTasks = new SubTaskRepository(_context, this);
        }
        public IUserRepository Users { get; private set; }

        public ITaskRepository Tasks { get; private set; }

        public ISubTaskRepository SubTasks { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITaskRepository Tasks { get; }
        ISubTaskRepository SubTasks { get; }
        int Complete();
    }
}

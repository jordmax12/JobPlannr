using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common.Models;

namespace Business.Context
{
    public class UserContext : DbContext
    {
        public UserContext()
            :base("name=UserContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<UserAccounts> Users { get; set; }
    }
}

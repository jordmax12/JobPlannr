using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common.Models;

namespace Business.Context
{
    public class BusinessContext : DbContext
    {
        public BusinessContext()
            :base("name=BusinessContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<BusinessContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<EmailSubscription> EmailSubscriptions { get; set; }
        public virtual DbSet<Planner> Planner { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Contributor> Contributors { get; set; }
        
    }
}

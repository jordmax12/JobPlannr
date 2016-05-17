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
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<User> Users { get; set; }


    }
}

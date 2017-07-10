using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common.Models;
using Business.Dto;

namespace Business.Context
{
    public class BusinessContext : DbContext
    {
        public BusinessContext()
            :base("name=BusinessContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<BusinessContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Planner, PlannerDto>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Helper, HelperDto>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Common.Models.Task, TaskDto>());
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<SubTask, SubTaskDto>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubTask>()
                .HasRequired(st => st.Task)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(st => st.TaskId);
           
          

            //modelBuilder.Entity<Common.Models.Task>()
            //    .HasMany<SubTask>(t => t.SubTasks);
                
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<EmailSubscription> EmailSubscriptions { get; set; }
        public virtual DbSet<Planner> Planner { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Common.Models.Task> Tasks { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }
        public virtual DbSet<Helper> Helpers { get; set; }
        
    }
}

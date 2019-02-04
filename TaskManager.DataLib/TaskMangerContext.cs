using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using TaskManager.Entities;
//using System.Data.Entity.ModelConfiguration.Configuration;
//using TaskManager.DataLib.Migrations;

namespace TaskManager.DataLib
{
    public class TaskMangerContext : DbContext
    {
        public TaskMangerContext() : base("name=TaskmanagerConn")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
           //Database.SetInitializer<TaskMangerContext>(new MigrateDatabaseToLatestVersion<TaskMangerContext, this.Configuration()>());
        }
   
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /*

            modelBuilder.Entity<Task>().
                 HasOptional(e => e.TaskParent).
                 WithMany().
                 HasForeignKey(m => m.TaskParentId);*/

        }
    }
}

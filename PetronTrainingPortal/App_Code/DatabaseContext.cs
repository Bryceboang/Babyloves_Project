using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetronTrainingPortal.App_Code
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<CompleteEmployeeTraining> CompleteEmployeeTrainings { get; set; }
        public DbSet<TrainingCapacity> TrainingCapacities { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new Initializer());
        //    modelBuilder.Entity<User>().ToTable("Users", "public");

        //    Database.SetInitializer(new Initializer());
        //    modelBuilder.Entity<Employee>().ToTable("Employees", "public");
        //}

        public class Initializer : IDatabaseInitializer<DatabaseContext>
        {
            public void InitializeDatabase(DatabaseContext context)
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    Seed(context);
                    context.SaveChanges();
                }
            }

            private void Seed(DatabaseContext context)
            {
                throw new NotImplementedException();
            }
        }
    }
}
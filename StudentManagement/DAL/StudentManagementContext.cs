using StudentManagement.Models;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace StudentManagement.DAL
{
    public class StudentManagementContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Class> Classes { get; set; } 
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Class>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Classes)
                .Map(t => t.MapLeftKey("ClassID")
                    .MapRightKey("StudentID")
                    .ToTable("ClassStudent"));
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList
{
    internal class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task_Category> Task_Category { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;password=159357;database=mydb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task_Category>()
                .HasOne(t => t.Task)
                .WithMany(tc => tc.Task_Categories)
                .HasForeignKey(ti => ti.TaskId);
            modelBuilder.Entity<Task_Category>()
               .HasOne(c => c.Category)
               .WithMany(tc => tc.Task_Categories)
               .HasForeignKey(ci => ci.CategoryId);
        }
    }
}

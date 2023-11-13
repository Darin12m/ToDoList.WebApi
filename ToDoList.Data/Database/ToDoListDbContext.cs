using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Databse
{
    public class ToDoListDbContext 
        : DbContext 
    {
        public ToDoListDbContext(DbContextOptions options) 
            : base(options) 
        {
        }

        public DbSet<ToDoLists>? Tasks { get; set; }

        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoLists>()
                .Property(x => x.Title)
                .HasMaxLength(50);

            modelBuilder.Entity<ToDoLists>()
                .Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<User>()
                .Property(x => x.UserName)
                .HasMaxLength(50);


        }

    }
}

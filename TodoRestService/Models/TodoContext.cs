using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace TodoRestService.Models
{
    public class TodoContext : DbContext, IDisposable
    {

        public DbSet<Item> Items { get; set; }


        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Item>().ToTable("Items");


            // Configure Primary Keys  
            modelBuilder.Entity<Item>().HasKey(ug => ug.Id).HasName("PK_Items");

            // Configure columns  
            modelBuilder.Entity<Item>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Item>().Property(ug => ug.TaskName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Item>().Property(ug => ug.StatusType).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Item>().Property(ug => ug.TaskDescription).HasColumnType("longtext").IsRequired();
            modelBuilder.Entity<Item>().Property(ug => ug.DueDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Item>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);
            modelBuilder.Entity<Item>().Property(u => u.FileName).HasColumnType("nvarchar(500)");
            modelBuilder.Entity<Item>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();



            // Configure relationships  

            base.OnModelCreating(modelBuilder);
        }
    }
}

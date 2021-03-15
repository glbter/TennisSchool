using System;
using Microsoft.EntityFrameworkCore;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Data.context
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<ChildInDb> ChildDbSet { get; private set; }
        public DbSet<GroupInDb> GroupDbSet { get; private set; }
        
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----------------child-------------------
            modelBuilder.Entity<ChildInDb>()
                .ToTable("Child")
                .HasKey(t => t.Id);
            
            modelBuilder.Entity<ChildInDb>()    
                .Property(it => it.PreferableDay)
                .HasConversion<string>();
                
            modelBuilder.Entity<ChildInDb>()    
                .Property(it => it.GameLevel)
                .HasConversion<string>();
            
            //---------------group--------------------------------
            modelBuilder.Entity<GroupInDb>()
                .ToTable("Group")
                .HasKey(t => t.Id);
            
            modelBuilder.Entity<GroupInDb>()    
                .Property(it => it.LessonsDay)
                .HasConversion<string>();

            modelBuilder.Entity<GroupInDb>()
                .Property(it => it.GameLevel)
                .HasConversion<string>();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123");
        }
    }
}
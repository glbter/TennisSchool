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
        public DbSet<ChildChosenDaysEntity> ChildChosenDaysDbSet { get; private set; }
        
        private readonly string _connectionString;
        
        public PostgresDbContext(string connectionString, DbContextOptions<PostgresDbContext> options) : base(options)
        {
            _connectionString = connectionString;
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
            
            //----------------days-------------------
            modelBuilder.Entity<ChildChosenDaysEntity>()
                .ToTable("ChildChosenDays")
                .HasKey(t => t.Id);

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
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
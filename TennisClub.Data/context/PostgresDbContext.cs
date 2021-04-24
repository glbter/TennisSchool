using System;
using Microsoft.EntityFrameworkCore;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Data.context
{
    public class PostgresDbContext : TennisClubContext
    {
        public override DbSet<ChildInDb> ChildDbSet { get; set; }
        public override DbSet<GroupInDb> GroupDbSet { get; set;}
        public override DbSet<ChildChosenDaysEntity> ChildChosenDaysDbSet { get; set;}
        
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
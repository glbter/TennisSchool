using Microsoft.EntityFrameworkCore;
using TennisClub.Data.Model;

namespace TennisClub.Data.Context
{
    public class PostgresDbContext : TennisClubContext
    {
        public override DbSet<ChildInDb> ChildDbSet { get; set; }
        public override DbSet<GroupInDb> GroupDbSet { get; set;}
        public override DbSet<ChildChosenDaysEntity> ChildChosenDaysDbSet { get; set;}

        private readonly string _connectionString;
        
        public PostgresDbContext(string connectionString, DbContextOptions<PostgresDbContext> options) : base(options)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        
    }
}
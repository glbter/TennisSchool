using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TennisClub.Data.Context
{
    public class PostgresDbContextFactory : IDesignTimeDbContextFactory<PostgresDbContext>
    {
        public PostgresDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>();
            // TODO: move to config
            string connectionString = "Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123";
            optionsBuilder.UseNpgsql(connectionString);
            return new PostgresDbContext(connectionString, optionsBuilder.Options);
        }
    }
}
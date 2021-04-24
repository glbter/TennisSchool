using Microsoft.EntityFrameworkCore;
using TennisClub.Data.model;

namespace TennisClub.Data.context
{
    public abstract class TennisClubContext : DbContext
    {
        public abstract DbSet<ChildInDb> ChildDbSet { get; set; }
        public abstract DbSet<GroupInDb> GroupDbSet { get; set;}
        public abstract DbSet<ChildChosenDaysEntity> ChildChosenDaysDbSet { get; set;}

        protected TennisClubContext(DbContextOptions options) : base(options) { }
        
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
    }
}
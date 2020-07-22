using LogError.Domain.Entities;
using LogError.Infra.Persistence.Map;
using Microsoft.EntityFrameworkCore;

namespace LogError.Infra.Persistence
{
    public class LogErrorContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LogInfo> LogInfos { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Log_Error; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new LogInfoMap());
            modelBuilder.ApplyConfiguration(new LogDetailMap());

            //modelBuilder.Entity<LogDetail>().HasKey(x => new
            //{
            //    x.LogInfoId
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}

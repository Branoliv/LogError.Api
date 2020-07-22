using LogError.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogError.Infra.Persistence.Map
{
    public class LogInfoMap : IEntityTypeConfiguration<LogInfo>
    {
        public void Configure(EntityTypeBuilder<LogInfo> builder)
        {
            builder.ToTable("LogInfo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnName("Title").IsRequired();
            builder.Property(x => x.Level).HasColumnName("Level").IsRequired();
            builder.Property(x => x.TokenSource).HasColumnName("TokenSource").IsRequired();
            builder.Property(x => x.Source).HasColumnName("Source").IsRequired();
        }
    }
}

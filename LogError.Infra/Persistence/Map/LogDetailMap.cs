using LogError.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogError.Infra.Persistence.Map
{
    class LogDetailMap : IEntityTypeConfiguration<LogDetail>
    {
        public void Configure(EntityTypeBuilder<LogDetail> builder)
        {
            builder.ToTable("LogDetail");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.LogInfo).WithMany(x => x.LogDetails);
            builder.Property(x => x.Detail).HasColumnName("Detail").IsRequired();
        }
    }
}

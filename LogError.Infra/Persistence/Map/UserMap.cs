using LogError.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogError.Infra.Persistence.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").IsRequired();
        }
    }
}

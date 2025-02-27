using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevkLine.Domain.Constants;
using SevkLine.Domain.Entities.Identity;

namespace SevkLine.Infrastructure.Configurations;

public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.Property(r => r.Name).IsRequired().HasMaxLength(ConfigurationConsts.MaxTitleLength);
    }
}
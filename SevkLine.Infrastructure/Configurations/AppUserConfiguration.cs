using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SevkLine.Domain.Constants;
using SevkLine.Domain.Entities.Identity;

namespace SevkLine.Infrastructure.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(ConfigurationConsts.MaxFirstNameLength);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(ConfigurationConsts.MaxFamilyNameLength);
        builder.Property(u => u.PartyIdentification).IsRequired().HasMaxLength(ConfigurationConsts.MaxPartyIdentificationLength);
        builder.Property(u => u.Address).IsRequired().HasMaxLength(ConfigurationConsts.MaxFullAddressLength);
        builder.Property(u => u.CityName).IsRequired().HasMaxLength(ConfigurationConsts.MaxCityNameLength);
        builder.Property(x => x.EmergencyContactNumber).HasMaxLength(ConfigurationConsts.MaxPhoneNumberLength);
        builder.Property(u => u.RefreshToken).HasMaxLength(ConfigurationConsts.MaxRefreshTokenLength);
        builder.Property(x => x.DepartmentId).IsRequired();
        
        builder.HasOne(u => u.Department)
            .WithMany(d => d.AppUsers)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
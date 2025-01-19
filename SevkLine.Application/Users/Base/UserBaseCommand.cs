using FluentValidation;
using SevkLine.Application.Roles.Base;
using SevkLine.Domain.Constants;

namespace SevkLine.Application.Users.Base;

public record UserBaseCommand
{
    public Guid DepartmentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PartyIdentification { get; set; }
    public required string Address { get; set; }
    public required string CityName { get; set; }
    public string? EmergencyContactNumber { get; set; }
}

public class UserBaseCommandValidator<T> : AbstractValidator<T> where T : UserBaseCommand
{
    public UserBaseCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(ConfigurationConsts.MaxFirstNameLength);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(ConfigurationConsts.MaxFamilyNameLength);
        RuleFor(x => x.PartyIdentification).NotEmpty().MaximumLength(ConfigurationConsts.MaxPartyIdentificationLength);
        RuleFor(x => x.Address).NotEmpty().MaximumLength(ConfigurationConsts.MaxFullAddressLength);
        RuleFor(x => x.CityName).NotEmpty().MaximumLength(ConfigurationConsts.MaxCityNameLength);
        RuleFor(x => x.DepartmentId).NotEmpty();
        RuleFor(x => x.EmergencyContactNumber).MaximumLength(ConfigurationConsts.MaxPhoneNumberLength);
    }
}
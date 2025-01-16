using FluentValidation;
using SevkLine.Domain.Constants;

namespace SevkLine.Application.Role.Base;

public record RoleBaseCommand
{
    public string Name { get; set; }
}

public class RoleBaseCommandValidator<T> : AbstractValidator<T> where T : RoleBaseCommand
{
    public RoleBaseCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxTitleLength); 
    }
}
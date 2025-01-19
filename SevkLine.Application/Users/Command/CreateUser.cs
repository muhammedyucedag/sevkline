using Ardalis.GuardClauses;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Common.GuardClauses;
using SevkLine.Application.Users.Base;
using SevkLine.Domain.Constants;
using SevkLine.Domain.Entities.Identity;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Users.Command;

public record CreateUserCommand : UserBaseCommand, IRequest<string>
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PhoneNumber { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateUserCommand, AppUser>();
        }
    }
}

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(ConfigurationConsts.MaxTitleLength);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(ConfigurationConsts.MaxElectronicMailLength).EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(ConfigurationConsts.MaxPasswordLength);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(ConfigurationConsts.MaxPhoneNumberLength);
    }
}

public class CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext context) : IRequestHandler<CreateUserCommand, string>
{
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.AlreadyExist(await context.Users.AnyAsync(x => x.PartyIdentification == request.PartyIdentification || x.UserName == request.UserName || x.Email == request.Email, cancellationToken), nameof(AppUser));

        var user = mapper.Map<AppUser>(request);
        
        user.Id = Guid.NewGuid().ToString(); 
        
        await userManager.CreateAsync(user, request.Password);

        return user.Id;
    }
}
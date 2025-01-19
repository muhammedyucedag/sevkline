using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SevkLine.Application.Roles.Base;
using SevkLine.Domain.Entities.Identity;

namespace SevkLine.Application.Roles.Command;

public record CreateRoleCommand : RoleBaseCommand, IRequest<string>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateRoleCommand, AppRole>();
        }
    }
}

public class CreateRoleValidator : RoleBaseCommandValidator<CreateRoleCommand>
{
    public CreateRoleValidator()
    {
    }
}

public class CreateRoleCommandHandler(RoleManager<AppRole> roleManager, IMapper mapper) : IRequestHandler<CreateRoleCommand, string>
{
    public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = mapper.Map<AppRole>(request);
        
        role.Id = Guid.NewGuid().ToString();

        await roleManager.CreateAsync(role);

        return role.Id;
    }
}

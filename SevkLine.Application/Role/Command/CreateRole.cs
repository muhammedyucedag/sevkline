using AutoMapper;
using MediatR;
using SevkLine.Application.Role.Base;
using SevkLine.Domain.Entities.Identity;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Role.Command;

public record CreateRoleCommand : RoleBaseCommand, IRequest<Guid>
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

public class CreateBranchCommandHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<CreateRoleCommand, Guid>
{
    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = mapper.Map<AppRole>(request);

        await context.Roles.AddAsync(role, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return role.Id;
    }
}

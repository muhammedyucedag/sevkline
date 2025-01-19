using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Roles.Base;
using SevkLine.Domain.Entities.Identity;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Roles.Command;

public record UpdateRoleCommand : RoleBaseCommand, IRequest<Unit>
{
    public string Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRoleCommand, AppRole>();
        }
    }
}

public class UpdateRoleValidator : RoleBaseCommandValidator<UpdateRoleCommand>
{
    public UpdateRoleValidator()
    {
    }
}

public class UpdateRoleCommandHandler(RoleManager<AppRole> roleManager, IMapper mapper, ApplicationDbContext context) : IRequestHandler<UpdateRoleCommand, Unit>
{
    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound($"{request.Id}", role);
        
        mapper.Map(request, role);
        role.NormalizedName = role.Name?.ToUpperInvariant();

        context.Roles.Update(role);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
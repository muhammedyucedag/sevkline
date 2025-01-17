using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Role.Base;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Role.Command;

public record DeleteRoleCommand(string Id) : RoleBaseCommand, IRequest<Unit>;

public class DeleteRoleValidator : RoleBaseCommandValidator<DeleteRoleCommand>
{
    public DeleteRoleValidator()
    {
    }
}

public class DeleteRoleCommandHandler(IMapper mapper, ApplicationDbContext context) : IRequestHandler<DeleteRoleCommand, Unit>
{
    public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound($"{request.Id}", role);
        
        context.Roles.Remove(role);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
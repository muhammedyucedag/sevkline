using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Departments.Base;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Departments.Command;

public record DeleteDepartmentCommand : DepartmentBaseCommand, IRequest<Unit>
{
    public Guid Id { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DeleteDepartmentCommand, Domain.Entities.Department>();
        }
    }
}

public class DeleteDepartmentValidator : DepartmentBaseCommandValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentValidator()
    {
    }
}

public class DeleteDepartmentCommandHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<DeleteDepartmentCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
        Guard.Against.NotFound($"{request.Id}", entity);
        
        context.Departments.Remove(entity);
        
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
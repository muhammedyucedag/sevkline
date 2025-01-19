using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Departments.Base;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Departments.Command;

public record UpdateDepartmentCommand : DepartmentBaseCommand, IRequest<Unit>
{
    public Guid Id { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateDepartmentCommand, Domain.Entities.Department>();
        }
    }
}

public class UpdateDepartmentValidator : DepartmentBaseCommandValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentValidator()
    {
    }
}

public class UpdateDepartmentCommandHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<UpdateDepartmentCommand, Unit>
{
    public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound($"{request.Id}", department);

        mapper.Map(request, department);

        context.Departments.Update(department);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
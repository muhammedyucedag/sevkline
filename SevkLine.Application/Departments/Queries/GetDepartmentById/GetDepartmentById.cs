using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Departments.Queries.Dtos;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Departments.Queries.GetDepartmentById;

public record GetDepartmentByIdQuery : IRequest<DepartmentDto>
{
    public Guid Id { get; set; }
}

public class GetDepartmentByIdQueryHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
        Guard.Against.NotFound($"{request.Id}", department);
        
        return mapper.Map<DepartmentDto>(department);
    }
}
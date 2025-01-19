using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SevkLine.Application.Departments.Queries.Dtos;
using SevkLine.Infrastructure.Persistence;

namespace SevkLine.Application.Departments.Queries.GetDepartments;
public class GetDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
{
    public string? Search { get; set; }
    public bool ShowDeleted { get; set; }
}

public class GetDepartmentsWithPaginationQueryHandler(ApplicationDbContext context, IMapper mapper) : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var queryable = context.Departments.AsQueryable();

        if (!request.ShowDeleted)
            queryable = queryable.Where(x => !x.IsDeleted);

        if (!string.IsNullOrEmpty(request.Search))
            queryable = queryable.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()));

        var departments = await queryable
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);

        return mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }
}
using AutoMapper;
using SevkLine.Application.Departments.Base;
using SevkLine.Domain.Entities;

namespace SevkLine.Application.Departments.Queries.Dtos;

public record DepartmentDto : DepartmentBaseCommand
{
    public Guid Id { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset LastModified { get; init; }
    public bool IsDeleted { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Department, DepartmentDto>();
        } 
    }
}

public class DepartmentBaseDtoValidator : DepartmentBaseCommandValidator<DepartmentDto>
{
}
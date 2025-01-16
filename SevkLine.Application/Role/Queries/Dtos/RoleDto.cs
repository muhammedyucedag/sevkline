using AutoMapper;
using SevkLine.Application.Role.Base;
using SevkLine.Domain.Entities.Identity;

namespace SevkLine.Application.Role.Queries.Dtos;

public record RoleDto : RoleBaseCommand
{
    public Guid Id { get; init; }
    public DateTimeOffset Created { get; init; }
    public DateTimeOffset LastModified { get; init; }
    
    public bool IsDeleted { get; init; }
    public bool IsActive { get; init; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppRole, RoleDto>();
        }
    }
}

public class RoleDtoValidator : RoleBaseCommandValidator<RoleDto>
{
}
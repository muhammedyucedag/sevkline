using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SevkLine.Application.Departments.Command;
using SevkLine.Application.Departments.Queries.Dtos;
using SevkLine.Application.Departments.Queries.GetDepartmentById;
using SevkLine.Application.Departments.Queries.GetDepartments;
using SevkLine.Application.Role.Command;
using SevkLine.Domain.Entities;

namespace SevkLine.Controller;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    [HttpGet]
    public async Task<Ok<IEnumerable<DepartmentDto>>> GetDepartments(ISender sender, [FromQuery] string? search, [FromQuery] bool showDeleted = false)
    {
        var query = new GetDepartmentsQuery
        {
            Search = search,
            ShowDeleted = showDeleted
        };

        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<Ok<DepartmentDto>> GetByIdDepartment(ISender sender, Guid id)
    {
        var query = new GetDepartmentByIdQuery { Id = id };
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
    
    [HttpPost]
    public async Task<Created<Guid>> CreateDepartment([FromServices] ISender sender, [AsParameters] CreateDepartmentCommand command)
    {
        var id = await sender.Send(command);
        return TypedResults.Created($"/{nameof(Department)}/{id}", id);
    }
    
    [HttpPut]
    public async Task<Results<NoContent, BadRequest>> UpdateDepartment([FromServices] ISender sender, Guid id, [AsParameters] UpdateDepartmentCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();  
        
        await sender.Send(command);
        return TypedResults.NoContent();
    }
        
    [HttpDelete]
    public async Task<NoContent> DeleteDepartment([FromServices] ISender sender, Guid id)
    {
        await sender.Send(new DeleteDepartmentCommand { Id = id });
        return TypedResults.NoContent();
    }
}
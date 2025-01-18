using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevkLine.Application.Departments.Command;
using SevkLine.Application.Role.Command;

namespace SevkLine.Controller;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromServices] ISender sender, [AsParameters] CreateDepartmentCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }

}
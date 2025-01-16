using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevkLine.Application.Role.Base;
using SevkLine.Application.Role.Command;

namespace SevkLine.Controller;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromServices] ISender sender, [AsParameters] CreateRoleCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }
}
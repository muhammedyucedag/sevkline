using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevkLine.Application.Roles.Command;

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
    
    [HttpPut]
    public async Task<IActionResult> UpdateRole([FromServices] ISender sender, Guid id, [AsParameters] UpdateRoleCommand command)
    {
        if (id.ToString() != command.Id) return BadRequest();  
        
        var result = await sender.Send(command);
        return Ok(result);
    }
        
    [HttpDelete]
    public async Task<IActionResult> DeleteRole([FromServices] ISender sender, string id)
    {
        await sender.Send(new DeleteRoleCommand(id));
        return NoContent();
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevkLine.Application.Users.Command;

namespace SevkLine.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromServices] ISender sender, [AsParameters] CreateUserCommand command)
    {
        var result = await sender.Send(command);
        return Ok(result);
    }
}
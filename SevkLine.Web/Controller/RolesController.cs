using MediatR;
using Microsoft.AspNetCore.Mvc;
using SevkLine.Application.Role.Base;

namespace SevkLine.Controller;

public class RolesController : ControllerBase
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleBaseCommand command)
        {
            var result = await sender.Send(command);
            return Ok(result);
        }
    }
}
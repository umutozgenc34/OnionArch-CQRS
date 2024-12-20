using Core.Security.Dtos;
using ECommerce.Application.Features.Auth.Commands.AuthLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginForUser(UserForLoginDto dto)
    {
        var response = await mediator.Send(new Login.Command(dto));
        return Ok(response);
    }
}

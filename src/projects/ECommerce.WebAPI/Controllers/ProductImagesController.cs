using ECommerce.Application.Features.ProductImages.Commands.Create;
using ECommerce.Application.Features.ProductImages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Upload(ProductImageAddCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new GetListProductImageQuery());
        return Ok(response);
    }
}

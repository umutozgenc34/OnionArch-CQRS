using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add(ProductAddCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new GetListProductQuery());
        return Ok(response);
    }
}

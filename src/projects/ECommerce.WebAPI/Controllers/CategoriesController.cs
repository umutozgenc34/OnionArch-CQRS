using Core.Application.Requests;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CategoryAddCommand command)
    {

        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetListCategoryQuery();

        var response = await _mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("paginate")]
    public async Task<IActionResult> GetPaginate([FromQuery] PageRequest pageRequest)
    {


        var query = new GetListByPaginateCategoryQuery { PageRequest = pageRequest };
        var response = await _mediator.Send(query);

        return Ok(response);

    }
}

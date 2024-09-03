using FwksLab.AppService.App.Api.Controllers.Common;
using FwksLab.AppService.Core.Abstractions.Services;
using FwksLab.AppService.Core.Inputs.Customers;
using FwksLab.AppService.Core.Outputs.Customers;
using FwksLab.Libs.AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace FwksLab.AppService.App.Api.Controllers;

public sealed class CustomersController(
    ICustomerService service) : V1Controller
{
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IReadOnlyCollection<CustomerOutput>), StatusCodes.Status200OK)]
    [HttpGet("")]
    public async Task<IResult> GetAsync()
    {
        return Results.Ok(await service.GetAsync());
    }

    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CustomerOutput), StatusCodes.Status201Created)]
    [HttpPost("")]
    public async Task<IResult> AddAsync(CustomerInput input)
    {
        var resource = await service.AddAsync(input);

        return Results.Created($"/customers/{resource?.Id}", resource);
    }

    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPatch("{id:guid}")]
    public async Task<IResult> UpdateAsync([FromRoute] Guid id, [FromBody] CustomerInput input)
    {
        await service.PatchAsync(id, input);

        return Results.Ok();
    }
}

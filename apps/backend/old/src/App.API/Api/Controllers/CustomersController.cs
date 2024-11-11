using FwksLabs.AppService.App.Api.Controllers.Common;
using FwksLabs.AppService.Core.Abstractions.Services;
using FwksLabs.AppService.Core.Resources.Customers.Inputs;
using FwksLabs.AppService.Core.Resources.Customers.Outputs;
using FwksLabs.Libs.AspNetCore.Models;
using FwksLabs.Libs.Core.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.AppService.App.Api.Controllers;

public sealed class CustomersController(
    ICustomerService service) : V1Controller
{
    [HttpGet("")]
    [ProducesResponseType(typeof(PageOutput<CustomerOutput>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAllAsync(CancellationToken cancellationToken) =>
        Ok(await service.GetAllAsync(cancellationToken));

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerOutput), StatusCodes.Status200OK)]
    public async Task<IResult> GetByIdAsync(string id, CancellationToken cancellationToken) =>
        Ok(await service.GetByIdAsync(id, cancellationToken));

    [HttpPost("")]
    [ProducesResponseType(typeof(IdOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> AddAsync([FromBody] CustomerInput input, CancellationToken cancellationToken) =>
        Created(await service.AddAsync(input, cancellationToken));

    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(IdOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateAsync([FromRoute] string id, [FromBody] CustomerInput input, CancellationToken cancellationToken) =>
        await Ok(() => service.UpdateAsync(input.WithId(id), cancellationToken));

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteByIdAsync([FromRoute] string id, CancellationToken cancellationToken) =>
        await NoContent(() => service.DeleteByIdAsync(id, cancellationToken));
}

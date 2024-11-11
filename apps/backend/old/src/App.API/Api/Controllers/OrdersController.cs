using FwksLabs.AppService.App.Api.Controllers.Common;
using FwksLabs.AppService.Core.Abstractions.Services;
using FwksLabs.AppService.Core.Resources.Orders.Inputs;
using FwksLabs.AppService.Core.Resources.Orders.Outputs;
using FwksLabs.Libs.AspNetCore.Models;
using FwksLabs.Libs.Core.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace FwksLabs.AppService.App.Api.Controllers;

public sealed class OrdersController(
    IOrderService service) : V1Controller
{
    [HttpGet("")]
    [ProducesResponseType(typeof(PageOutput<OrderOutput>), StatusCodes.Status200OK)]
    public async Task<IResult> GetAllAsync(CancellationToken cancellationToken) =>
        Ok(await service.GetAllAsync(cancellationToken));

    [HttpGet("customers/{id}")]
    [ProducesResponseType(typeof(PageOutput<OrderOutput>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> GetByCustomerIdAsync([FromRoute] string id, CancellationToken cancellationToken) =>
        Ok(await service.GetByCustomerIdAsync(id, cancellationToken));

    [HttpPost("")]
    [ProducesResponseType(typeof(IdOutput), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> AddAsync([FromBody] OrderInput input, CancellationToken cancellationToken) =>        
        Created(await service.AddAsync(input, cancellationToken));


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(AppProblem), StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteByIdAsync([FromRoute] string id, CancellationToken cancellationToken) =>
        await NoContent(() => service.DeleteByIdAsync(id, cancellationToken));
}
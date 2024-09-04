using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FwksLabs.Libs.AspNetCore.Filters;

public sealed class SwaggerParametersOperationFilter(
    IReadOnlyCollection<OpenApiParameter> parameters) : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= [];

        foreach (var parameter in parameters)
            operation.Parameters.Add(parameter);
    }
}

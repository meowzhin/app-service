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
        {
            if (operation.Parameters.Any(x => x.Name == parameter.Name))
                continue;

            operation.Parameters.Add(parameter);
        }
    }
}

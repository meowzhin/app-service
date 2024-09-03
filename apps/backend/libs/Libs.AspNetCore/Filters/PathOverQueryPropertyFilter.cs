using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FwksLab.Libs.AspNetCore.Filters;

// TODO: Check this
public sealed class PathOverQueryPropertyFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var types = new List<ParameterLocation> { ParameterLocation.Query, ParameterLocation.Path };

        var duplicates = operation.Parameters
            .Where(x => x.In.HasValue && types.Contains(x.In.Value))
            .GroupBy(x => x.Name).Where(x => x.Count() > 1)
            .SelectMany(x => x.Select(x => x.Name))
            .Distinct();

        operation.Parameters = operation.Parameters.Except(
                operation.Parameters.Where(x =>
                    x.In == ParameterLocation.Query &&
                    duplicates.Any(p => p.Equals(x.Name, StringComparison.InvariantCultureIgnoreCase)))).ToList();
    }
}
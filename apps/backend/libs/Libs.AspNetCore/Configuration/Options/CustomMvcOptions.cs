using System.Net.Mime;
using FwksLabs.Libs.AspNetCore.Attributes;
using FwksLabs.Libs.AspNetCore.Conventions;
using FwksLabs.Libs.AspNetCore.Filters;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public sealed class CustomMvcOptions(
    ILogger<CustomMvcOptions> logger) : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.ProblemJson));
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));

        options.Filters.Add(new AppProblemResponseAttribute(StatusCodes.Status500InternalServerError));
        options.Filters.Add(new AppProblemResponseAttribute(StatusCodes.Status401Unauthorized));

        options.Filters.Add<AppProblemResultFilter>();

        options.Conventions.Add(new SlugCaseRouteTransformerConvention());
    }
}

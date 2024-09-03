using System.Net.Mime;
using FwksLab.Libs.AspNetCore.Attributes;
using FwksLab.Libs.AspNetCore.Conventions;
using FwksLab.Libs.AspNetCore.Filters;
using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public sealed class CustomMvcOptions(
    ILogger<CustomMvcOptions> logger) : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));

        options.Filters.Add(new AppProblemResponseAttribute(StatusCodes.Status500InternalServerError));
        options.Filters.Add(new AppProblemResponseAttribute(StatusCodes.Status401Unauthorized));

        options.Filters.Add<AppProblemResultFilter>();

        options.Conventions.Add(new SlugCaseRouteTransformerConvention());
    }
}

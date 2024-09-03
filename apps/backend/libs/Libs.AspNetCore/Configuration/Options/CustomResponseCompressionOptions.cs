using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public class CustomResponseCompressionOptions(
    ILogger<CustomResponseCompressionOptions> logger) : IConfigureOptions<ResponseCompressionOptions>
{
    public virtual void Configure(ResponseCompressionOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.EnableForHttps = true;
        options.Providers.Add<GzipCompressionProvider>();
        options.Providers.Add<BrotliCompressionProvider>();
    }
}
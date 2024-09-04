using System.IO.Compression;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public class CustomGzipCompressionProviderOptions(
    ILogger<CustomGzipCompressionProviderOptions> logger) : IConfigureOptions<GzipCompressionProviderOptions>
{
    public virtual void Configure(GzipCompressionProviderOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.Level = CompressionLevel.Optimal;
    }
}
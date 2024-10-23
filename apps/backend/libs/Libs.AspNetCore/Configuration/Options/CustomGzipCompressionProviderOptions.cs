using System.IO.Compression;
using Humanizer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public class CustomGzipCompressionProviderOptions(
    ILogger<CustomGzipCompressionProviderOptions> logger) : IConfigureOptions<GzipCompressionProviderOptions>
{
    public virtual void Configure(GzipCompressionProviderOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        options.Level = CompressionLevel.Optimal;
    }
}
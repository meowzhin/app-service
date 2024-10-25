using System.IO.Compression;
using Humanizer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration.Options;

public class ConfigureBrotliCompressionProviderOptions(
    ILogger<ConfigureBrotliCompressionProviderOptions> logger) : IConfigureOptions<BrotliCompressionProviderOptions>
{
    public virtual void Configure(BrotliCompressionProviderOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.Humanize());

        options.Level = CompressionLevel.Optimal;
    }
}
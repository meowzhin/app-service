using System.IO.Compression;
using FwksLab.Libs.Core.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration.Options;

public class CustomBrotliCompressionProviderOptions(
    ILogger<CustomBrotliCompressionProviderOptions> logger) : IConfigureOptions<BrotliCompressionProviderOptions>
{
    public virtual void Configure(BrotliCompressionProviderOptions options)
    {
        logger.LogInformation("Configuring '{OptionsType}'", GetType().Name.SpaceTitleCase());

        options.Level = CompressionLevel.Optimal;
    }
}
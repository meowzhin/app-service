using FwksLab.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLab.Libs.AspNetCore.Configuration;

public static class CompressionConfiguration
{
    public static IServiceCollection OverrideCompressionOptions(this IServiceCollection services)
    {
        return services
            .AddTransient<IConfigureOptions<GzipCompressionProviderOptions>, CustomGzipCompressionProviderOptions>()
            .AddTransient<IConfigureOptions<BrotliCompressionProviderOptions>, CustomBrotliCompressionProviderOptions>()
            .AddTransient<IConfigureOptions<ResponseCompressionOptions>, CustomResponseCompressionOptions>();
    }

    public static IServiceCollection OverrideCompressionOptions<TGzip, TBrotli, TResponse>(this IServiceCollection services)
        where TGzip : class, IConfigureOptions<GzipCompressionProviderOptions>
        where TBrotli : class, IConfigureOptions<BrotliCompressionProviderOptions>
        where TResponse : class, IConfigureOptions<ResponseCompressionOptions>
    {
        return services
            .AddTransient<IConfigureOptions<GzipCompressionProviderOptions>, TGzip>()
            .AddTransient<IConfigureOptions<BrotliCompressionProviderOptions>, TBrotli>()
            .AddTransient<IConfigureOptions<ResponseCompressionOptions>, TResponse>();
    }
}
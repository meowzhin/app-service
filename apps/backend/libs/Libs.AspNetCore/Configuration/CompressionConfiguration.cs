using FwksLabs.Libs.AspNetCore.Configuration.Options;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FwksLabs.Libs.AspNetCore.Configuration;

public static class CompressionConfiguration
{
    public static IServiceCollection OverrideCompressionOptions(this IServiceCollection services) =>
        services
            .AddTransient<IConfigureOptions<GzipCompressionProviderOptions>, ConfigureGzipCompressionProviderOptions>()
            .AddTransient<IConfigureOptions<BrotliCompressionProviderOptions>, ConfigureBrotliCompressionProviderOptions>()
            .AddTransient<IConfigureOptions<ResponseCompressionOptions>, ConfigureResponseCompressionOptions>();

    public static IServiceCollection OverrideCompressionOptions<TGzip, TBrotli, TResponse>(this IServiceCollection services)
        where TGzip : class, IConfigureOptions<GzipCompressionProviderOptions>
        where TBrotli : class, IConfigureOptions<BrotliCompressionProviderOptions>
        where TResponse : class, IConfigureOptions<ResponseCompressionOptions> =>
            services
                .AddTransient<IConfigureOptions<GzipCompressionProviderOptions>, TGzip>()
                .AddTransient<IConfigureOptions<BrotliCompressionProviderOptions>, TBrotli>()
                .AddTransient<IConfigureOptions<ResponseCompressionOptions>, TResponse>();
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.Libs.Infra.Postgres.Extensions;

public static class PropertyConfigurationExtensions
{
    private readonly static string JSONB = "jsonb";

    public static PropertyBuilder<TModel> HasJsonbType<TModel>(this PropertyBuilder<TModel> builder) =>
        builder.HasColumnType(JSONB);
}

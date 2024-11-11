using System.Linq.Expressions;
using System.Text.Json;
using FwksLabs.Libs.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FwksLabs.ResumeService.Infra.Data.Extensions;

public static class TypeConfigurationExtensions
{
    public static ReferenceCollectionBuilder HasForeignKey<TPrincipal, TDependent>(this ReferenceCollectionBuilder<TPrincipal, TDependent> builder, Expression<Func<TDependent, object?>> expression, string tableName)
        where TPrincipal : class
        where TDependent : class
    {
        string? propertyName;

        if (expression.Body is UnaryExpression unaryExpression)
            propertyName = (unaryExpression.Operand as MemberExpression)?.Member.Name;
        else if (expression.Body is MemberExpression memberExpression)
            propertyName = memberExpression.Member.Name;
        else
            throw new ArgumentException("Invalid expression type.");

        return builder
            .HasForeignKey(expression)
            .HasConstraintName($"FK_{tableName}_{propertyName}")
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static PropertyBuilder<TEntity> IsJsonb<TEntity>(this PropertyBuilder<TEntity> builder) where TEntity : class =>
        builder.HasColumnType("jsonb");

    public static PropertyBuilder<TEntity> HasJsonConverter<TEntity>(this PropertyBuilder<TEntity> builder, Action<JsonSerializerOptions>? optionsAction = null) where TEntity : class
    {
        var converter = new ValueConverter<TEntity, string>(
            entity => entity.Serialize(optionsAction),
            serialized => serialized.Deserialize<TEntity>(optionsAction));

        return builder.HasConversion(converter);
    }
}
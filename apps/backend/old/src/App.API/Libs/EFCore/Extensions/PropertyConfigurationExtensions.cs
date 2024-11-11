using System.Linq.Expressions;
using FwksLabs.Libs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.Libs.Infra.EntityFrameworkCore.Extensions;

public static class PropertyConfigurationExtensions
{
    public static ReferenceCollectionBuilder DisableCascade(this ReferenceCollectionBuilder builder) =>
        builder.OnDelete(DeleteBehavior.Restrict);

    public static IndexBuilder<T> HasUniqueIndex<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, object?>> expression, string tableName)
        where T : Entity<int>
    {
        var memberExpression = expression.Body as MemberExpression;

        return
            builder
            .HasIndex(expression)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{tableName}_{memberExpression!.Member.Name}");
    }

    public static void HasUniqueIndex<TOwnerEntity, TDependentEntity>(this OwnedNavigationBuilder<TOwnerEntity, TDependentEntity> builder, Expression<Func<TDependentEntity, object?>> expression, string tableName)
        where TOwnerEntity : class
        where TDependentEntity : class

    {
        var memberExpression = expression.Body as MemberExpression;

        builder
            .HasIndex(expression)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{tableName}_{memberExpression!.Member.Name}");
    }

    public static ReferenceCollectionBuilder HasForeignKey<TPrincipal, TDependent>(this ReferenceCollectionBuilder<TPrincipal, TDependent> builder, Expression<Func<TDependent, object?>> expression, string tableName, string key)
        where TPrincipal : class
        where TDependent : class
    {
        return
            builder
                .HasForeignKey(expression)
                .HasConstraintName($"FK_{tableName}_{key}")
                .OnDelete(DeleteBehavior.Restrict);
    }

    public static OwnershipBuilder HasForeignKey<TPrincipal, TDependent>(this OwnershipBuilder<TPrincipal, TDependent> builder, Expression<Func<TDependent, object?>> expression, string tableName, string key)
        where TPrincipal : class
        where TDependent : class
    {
        return
            builder
                .HasForeignKey(expression)
                .HasConstraintName($"FK_{tableName}_{key}");
    }
}
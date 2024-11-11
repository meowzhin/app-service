using FwksLabs.Libs.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.Libs.Postgres.Configuration;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual string? TableName { get; }
    public virtual string SchemaName { get; } = "App";

    public virtual void Extend(EntityTypeBuilder<TEntity> builder) { }

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var tableName = TableName ?? typeof(TEntity).Name.Replace("Entity", string.Empty);

        builder
            .ToTable(tableName, SchemaName)
            .HasKey(x => x.Id)
            .HasName($"PK_{TableName}");

        builder
            .HasIndex(x => x.ReferenceId)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{TableName}");

        Extend(builder);
    }
}
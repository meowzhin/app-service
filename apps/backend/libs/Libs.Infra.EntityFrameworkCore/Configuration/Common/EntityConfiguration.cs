using FwksLabs.Libs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.Libs.Infra.EntityFrameworkCore.Configuration.Common;

public abstract class EntityConfiguration<TEntity>() : IEntityTypeConfiguration<TEntity> where TEntity : Entity<int>
{
    public virtual string? TableName { get; private set; } = default;
    public virtual string SchemaName { get; private set; } = "App";

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        TableName ??= typeof(TEntity).Name.Replace("Entity", string.Empty);

        builder
            .ToTable(TableName, SchemaName)
            .HasKey(x => x.Id)
            .HasName($"PK_{TableName}");

        builder
            .HasIndex(x => x.UniqueId)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{TableName}");

        Extend(builder);
    }

    public virtual void Extend(EntityTypeBuilder<TEntity> builder) { }
}

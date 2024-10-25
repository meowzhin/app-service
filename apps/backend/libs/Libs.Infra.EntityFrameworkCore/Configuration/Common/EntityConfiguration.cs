using FwksLabs.Libs.Core.Types;
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
            .HasKey(static x => x.Id)
            .HasName($"PK_{TableName}");

        builder
            .HasIndex(static x => x.UniqueId)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{TableName}");

        builder
            .HasQueryFilter(static x => !x.IsDeleted);

        builder
            .HasIndex(static x => x.IsDeleted)
            .HasDatabaseName($"IX_{TableName}_IsDeleted")
            .HasFilter("IsDeleted = 0");

        Extend(builder);
    }

    public virtual void Extend(EntityTypeBuilder<TEntity> builder) { }
}

using FwksLab.Libs.Core.Entities;
using FwksLab.Libs.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLab.Libs.Infra.EntityFrameworkCore.Configuration.Common;

public abstract class EntityConfiguration<T>(
    string? name = null, string schema = "App") : IEntityTypeConfiguration<T> where T : Entity<int>
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        var typeIdentifier = typeof(T).Name.Replace("Entity", string.Empty);

        builder
            .ToTable(name ?? typeIdentifier.ToSnakeCase(), schema)
            .HasKey(x => x.Id)
            .HasName($"PK_{typeIdentifier}");

        builder
            .HasIndex(x => x.UniqueId)
            .IsUnique()
            .HasDatabaseName($"IX_UK_{typeIdentifier}");

        Extend(builder);
    }

    public virtual void Extend(EntityTypeBuilder<T> builder) { }
}

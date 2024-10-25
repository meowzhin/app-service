using FwksLabs.Libs.Core.Types;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FwksLabs.Libs.Infra.Mongo.Configuration;

public abstract class EntityConfiguration<TEntity>(string? name = null) : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity<Guid>
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var typeIdentifier = typeof(TEntity).Name.Replace("Entity", string.Empty);

        builder
            .ToCollection(name ?? typeIdentifier.Camelize())
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.UniqueId)
            .IsUnique();

        Extend(builder);
    }

    public virtual void Extend(EntityTypeBuilder<TEntity> builder) { }
}


//public sealed class MongoDbHealthCheck(
//    ILogger<MongoDbHealthCheck> logger,
//    IMongoDatabase database) : IHealthCheck
//{
//    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
//    {
//        try
//        {
//            await database.RunCommandAsync((Command<BsonDocument>)"{ping:1}", cancellationToken: cancellationToken);

//            return HealthCheckResult.Unhealthy("Mongo is fine.");
//        }
//        catch (Exception ex)
//        {
//            logger.LogError(ex, "Failed to check mongo dependency");

//            return HealthCheckResult.Unhealthy("Mongo is unreachable.");
//        }
//    }
//}
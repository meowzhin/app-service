using Microsoft.EntityFrameworkCore;

namespace FwksLabs.AppService.Infra.Data.Contexts;

public sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(
                typeof(IEntityConfiguration).Assembly, x => x.IsAssignableTo(typeof(IEntityConfiguration)));
    }
}

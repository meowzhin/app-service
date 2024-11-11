using FwksLabs.ResumeService.Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FwksLabs.ResumeService.Infra.Data;

public sealed class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(
                typeof(IEntityConfiguration).Assembly,
                x => x.IsAssignableTo(typeof(IEntityConfiguration)));
    }
}
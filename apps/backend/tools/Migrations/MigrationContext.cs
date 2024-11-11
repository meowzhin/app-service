using FwksLabs.Libs.Core.Extensions;
using FwksLabs.ResumeService.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FwksLabs.Migrations;

public sealed record MigrationSettings(string ConnectionString);

public sealed class MigrationContext : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var settings = File.ReadAllText("./appsettings.json").Deserialize<MigrationSettings>();

        var builder = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(settings.ConnectionString, x =>
            {
                x.MigrationsHistoryTable("Migrations", "History");
                x.MigrationsAssembly(typeof(MigrationContext).Assembly.FullName);
            });

        return new DatabaseContext(builder.Options);
    }
}
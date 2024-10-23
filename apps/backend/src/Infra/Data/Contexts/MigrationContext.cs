using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FwksLabs.AppService.Core.Configuration.Settings;

namespace FwksLabs.ResumeService.Infra.Data.Contexts;

public sealed class MigrationContext : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var appSettings = JsonSerializer.Deserialize<AppSettings>(
            File.ReadAllText(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent!.FullName, "App.Api", "appsettings.json")));

        var builder = new DbContextOptionsBuilder<DatabaseContext>()
            .UseNpgsql(appSettings!.Persistence.Postgres.Build(), static x => x.MigrationsHistoryTable("Migrations", "History"));

        return new DatabaseContext(builder.Options);
    }
}
#pragma warning disable S1481 // Unused local variables should be removed
#pragma warning disable S1075 // Absolute Paths
#pragma warning disable S3903 // Namespace

using System.Text.Json;
using FwksLab.AppService.Core.Configuration.Settings;
using Npgsql;

try
{
    var appSettings = JsonSerializer.Deserialize<AppSettings>(
        await File.ReadAllTextAsync(Path.Combine(@"D:\git\fwks-app-service\apps\backend\src\App.Api\appsettings.json")));

    await using var conn = new NpgsqlConnection(appSettings!.Persistence.Postgres.ConnectionString);

    await conn.OpenAsync();

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

internal record EntityStub(Guid Id);
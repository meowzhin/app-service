namespace FwksLabs.ResumeService.Core.Configuration.Settings;

public interface IConnectionString
{
    string ConnectionString { get; set; }
}

public sealed class AppSettings
{
    public SQLiteSettings Postgres { get; set; } = new();
}

public sealed record SQLiteSettings : IConnectionString
{
    public string ConnectionString { get; set; } = string.Empty;
}
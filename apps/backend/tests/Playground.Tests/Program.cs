using FwksLabs.ResumeService.Core.Types;
using FwksLabs.ResumeService.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

try
{
    var options = new DbContextOptionsBuilder<DatabaseContext>()
        .UseNpgsql("Host=localhost;Port=5432;Username=local;Password=local;Database=postgres", x => x.MigrationsHistoryTable("Migrations", "History"));

    var context = new DatabaseContext(options.Options);

    var customers = context.Set<ProfileEntity>().ToListAsync();
}
catch (Exception e)
{
    throw;
}
using Microsoft.EntityFrameworkCore;

namespace Rsoi.Lab2.LibraryService.HttpApi.Extensions;

public static class DatabaseMigrationExtension
{
    public static IHost MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<TContext>();
        
        context.Database.Migrate();

        return host;
    }
}
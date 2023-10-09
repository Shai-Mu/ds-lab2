using Microsoft.AspNetCore.Hosting;
using Rsoi.Lab2.LibraryService.Database;
using Rsoi.Lab2.LibraryService.HttpApi.Extensions;

namespace Rsoi.Lab2.LibraryService.HttpApi;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDatabase<LibraryContext>()
                .Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Serilog
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults((webBuilder) =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
using Microsoft.AspNetCore.Hosting;

namespace Rsoi.Lab2.LibrarySystem;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            CreateHostBuilder(args)
                .Build()
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
using Rsoi.Lab2.LibrarySystem;

namespace Rsoi.Lab2.GatewayService.HttpApi;

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
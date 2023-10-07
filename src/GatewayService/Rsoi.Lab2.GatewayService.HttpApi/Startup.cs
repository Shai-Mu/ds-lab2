using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;

namespace Rsoi.Lab2.LibrarySystem;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            
            .AddNewtonsoftJson();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OpenAPI definition", Version = "v1" });
            
        });
        services.AddSwaggerGenNewtonsoftSupport();

        services.AddControllers()
            .AddNewtonsoftJson();
        
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpenAPI definition v1"));

        app.UseRouting();
        app.UseCors("policy"); // Must be after Routing and before Authorization middlewares.

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
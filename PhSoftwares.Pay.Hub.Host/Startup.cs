using Microsoft.Extensions.Configuration;
using PhSoftwares.Pay.Hub.Infrastructure.DependencyInjection;

public class Startup
{
    public IConfiguration Configuration {  get; set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddInfrastructure(Configuration);
    }

    public void ConfigureMiddleware(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();     
    }
}

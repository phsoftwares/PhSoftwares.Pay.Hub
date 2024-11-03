using Microsoft.EntityFrameworkCore;
using PhSoftwares.Pay.Hub.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
// Add services to the container.
startup.ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}


// Configure the HTTP request pipeline.
startup.ConfigureMiddleware(app, app.Environment);

app.MapControllers();
app.Run();

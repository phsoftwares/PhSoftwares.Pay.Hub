using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Mappings;
using PhSoftwares.Pay.Hub.Application.Services;
using PhSoftwares.Pay.Hub.Infrastructure.Context;
using PhSoftwares.Pay.Hub.Infrastructure.Repositories;

namespace PhSoftwares.Pay.Hub.Infrastructure.DependencyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<IRecipientRepository, RecipientRepository>();

            services.AddScoped<IPayerMapper, PayerMapper>();
            services.AddScoped<IRecipientMapper, RecipientMapper>();

            services.AddScoped<IPayerService, PayerService>();
            services.AddScoped<IRecipientService, RecipientService>();


            services.AddScoped<IPaymentPixService, PaymentPixService>();


            return services;
        }
    }
}

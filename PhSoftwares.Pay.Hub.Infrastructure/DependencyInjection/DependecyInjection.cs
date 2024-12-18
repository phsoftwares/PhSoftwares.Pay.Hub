﻿
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappers;
using PhSoftwares.Pay.Hub.Application.Interfaces.Mappings;
using PhSoftwares.Pay.Hub.Application.Interfaces.Repositories;
using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Application.Mappers;
using PhSoftwares.Pay.Hub.Application.Mappings;
using PhSoftwares.Pay.Hub.Application.Services;
using PhSoftwares.Pay.Hub.Boleto.Interfaces.Mappers;
using PhSoftwares.Pay.Hub.Core.Account;
using PhSoftwares.Pay.Hub.Infrastructure.Context;
using PhSoftwares.Pay.Hub.Infrastructure.Identity;
using PhSoftwares.Pay.Hub.Infrastructure.Repositories;
using System.Text;

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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddHttpClient();

            services.AddScoped<IBoletoBancoBrasilMapper, BoletoBancoBrasilMapper>();
            services.AddScoped<IBoletoBancoBrasilService, BoletoBancoBrasilService>();

            services.AddScoped<IBoletoSicrediMapper, BoletoSicrediMapper>();
            services.AddScoped<IBoletoSicrediService, BoletoSicrediService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddScoped<IPayerRepository, PayerRepository>();
            services.AddScoped<IPayeeRepository, PayeeRepository>();

            services.AddScoped<IPayerMapper, PayerMapper>();
            services.AddScoped<IPayeeMapper, PayeeMapper>();

            services.AddScoped<IPayerService, PayerService>();
            services.AddScoped<IPayeeService, PayeeService>();


            services.AddScoped<IPaymentPixService, PaymentPixService>();
            services.AddScoped<IPaymentBoletoService, PaymentBoletoService>();

            return services;
        }
    }
}

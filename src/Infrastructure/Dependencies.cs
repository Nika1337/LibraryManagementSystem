using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;
using Nika1337.Library.Infrastructure.Identity.Entities;
using Nika1337.Library.Infrastructure.Identity.Services;
using Nika1337.Library.Infrastructure.Logging;
using Nika1337.Library.Infrastructure.Services;
using System;

namespace Nika1337.Library.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // use real database
        services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LibraryConnection")), ServiceLifetime.Transient);

        // Add Identity DbContext
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")), ServiceLifetime.Transient);

        services.AddTransient<IUserValidator<IdentityEmployee>, OptionalEmailUserValidator<IdentityEmployee>>();

        services.AddIdentity<IdentityEmployee, IdentityEmployeeRole>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
        })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders()
            .AddPasswordValidator<EmployeePasswordValidator>();

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });

        services.AddScoped<INavigationMenuService, NavigationMenuService>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddScoped<IEmployeeAuthenticationService, IdentityEmployeeAuthenticationService>();
        services.AddScoped<IEmployeeService, IdentityEmployeeService>();
        services.AddTransient<IEmailSender, MailJetEmailSender>();
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    }
}
using Mailjet.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Services;
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
            o.User.RequireUniqueEmail = true;
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

        services.AddScoped<IMailjetClient>(provider =>
        {
            var apiKey = configuration["MailjetConfiguration:MailjetApiKey"];
            var secretKey = configuration["MailjetConfiguration:MailjetSecretKey"];
            return new MailjetClient(apiKey, secretKey);
        });

        services.AddTransient<IEmailSender, MailJetEmailSender>();
        
        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IRepository<EmailTemplate>, IdentityEfRepository<EmailTemplate>>();
        services.AddScoped<IReadRepository<EmailTemplate>, IdentityEfRepository<EmailTemplate>>();

        services.AddScoped(typeof(IRepository<>), typeof(LibraryEfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(LibraryEfRepository<>));
    }
}
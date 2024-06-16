using Mailjet.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;
using Nika1337.Library.Infrastructure.Identity.Entities;
using Nika1337.Library.Infrastructure.Identity.Validators;
using Nika1337.Library.Infrastructure.Logging;
using Nika1337.Library.Infrastructure.Services;
using System;

namespace Nika1337.Library.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration);

        services.ConfigureIdentity();

        services.AddEmailSender(configuration);

        services.AddLoggingAdapter();

        services.AddRepositories();

        services.AddServices();
    }

    private static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LibraryConnection")), ServiceLifetime.Transient);

        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")), ServiceLifetime.Transient);
    }

    private static void ConfigureIdentity(this IServiceCollection services)
    {

        services.AddTransient<IUserValidator<IdentityEmployee>, OptionalEmailUserValidator<IdentityEmployee>>();

        services.AddIdentity<IdentityEmployee, IdentityEmployeeRole>(o =>
        {
            o.Stores.MaxLengthForKeys = 128;
            o.User.RequireUniqueEmail = true;
        })
            .AddUserStore<UserStore<IdentityEmployee, IdentityEmployeeRole, IdentityContext, string, IdentityUserClaim<string>, IdentityEmployeeRoleJunction, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>>()
            .AddRoleStore<RoleStore<IdentityEmployeeRole, IdentityContext, string, IdentityEmployeeRoleJunction, IdentityRoleClaim<string>>>()
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

    }

    private static void AddEmailSender(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMailjetClient>(provider =>
        {
            var apiKey = configuration["MailjetConfiguration:MailjetApiKey"];
            var secretKey = configuration["MailjetConfiguration:MailjetSecretKey"];
            return new MailjetClient(apiKey, secretKey);
        });

        services.AddTransient<IEmailSender, MailJetEmailSender>();
    }

    private static void AddLoggingAdapter(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(LibraryEfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(LibraryEfRepository<>));
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeAuthenticationService, IdentityEmployeeAuthenticationService>();
        services.AddScoped<IEmployeeService, IdentityEmployeeService>();
        services.AddScoped<IEmployeeRoleService, IdentityEmployeeRoleService>();

        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IBookService, BookService>();

        services.AddScoped<INavigationMenuService, NavigationMenuService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}

using Nika1337.Library.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;
using NLog;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureServices(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/EmployeeAccount/SignIn";
    options.LogoutPath = "/EmployeeAccount/SignOut";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build());

var presentationAssembly = typeof(Nika1337.Library.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddApplicationPart(presentationAssembly);


builder.Services.AddAutoMapper(
    typeof(Nika1337.Library.Presentation.AssemblyReference).Assembly,
    typeof(Nika1337.Library.Infrastructure.AssemblyReference).Assembly);


var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    var logger = app.Services.GetRequiredService<ILoggerManager>();

    app.ConfigureExceptionHandler(logger);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "..", "Presentation", "wwwroot"))
});

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();

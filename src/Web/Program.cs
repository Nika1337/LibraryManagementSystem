
using Nika1337.Library.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using System.IO;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigureServices(builder.Configuration);


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/EmployeeAccount/SignIn";
    options.LogoutPath = "/EmployeeAccount/SignOut";
});

builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

var presentationAssembly = typeof(Nika1337.Library.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllersWithViews()
    .AddApplicationPart(presentationAssembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "username",
        pattern: "{controller}/{action}/{username}"
        );

app.Run();

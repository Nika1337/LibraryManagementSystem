
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
    options.AccessDeniedPath = "/AccessDenied";
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
    .AddApplicationPart(presentationAssembly);


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/SomethingWentWrong");
    app.UseStatusCodePagesWithReExecute("/Error");
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

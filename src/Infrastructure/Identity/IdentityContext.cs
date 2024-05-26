using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Infrastructure.Identity.Config;
using Nika1337.Library.Infrastructure.Identity.Entities;


namespace Nika1337.Library.Infrastructure.Identity;

public class IdentityContext(DbContextOptions<IdentityContext> options) : IdentityDbContext<IdentityEmployee, IdentityEmployeeRole, string>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new IdentityEmployeeRoleConfiguration());
        builder.ApplyConfiguration(new NavigationMenuItemConfiguration());
        builder.ApplyConfiguration(new IdentityEmployeeConfiguration());
    }
}
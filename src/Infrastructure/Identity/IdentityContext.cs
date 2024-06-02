using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.Infrastructure.Identity.Config;
using Nika1337.Library.Infrastructure.Identity.Entities;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.AspNetCore.Http;
using Ardalis.Specification;
using Nika1337.Library.Infrastructure.Logging.Audit;


namespace Nika1337.Library.Infrastructure.Identity;

internal class IdentityContext(
    IHttpContextAccessor httpContextAccessor,
    DbContextOptions<IdentityContext> options) : IdentityDbContext<IdentityEmployee, IdentityEmployeeRole, string>(options)
{

    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public DbSet<EmailTemplate> EmailTemplates { get; set; }

    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AuditLogConfiguration());
        builder.ApplyConfiguration(new EmailTemplateConfiguration());
        builder.ApplyConfiguration(new IdentityEmployeeRoleConfiguration());
        builder.ApplyConfiguration(new NavigationMenuItemConfiguration());
        builder.ApplyConfiguration(new IdentityEmployeeConfiguration());
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        LogModifiedEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        LogModifiedEntities();

        return base.SaveChanges();
    }


    private void LogModifiedEntities()
    {
        LoggingHelper.LogModifiedEntities(
            ChangeTracker,
            _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!,
            AuditLogs);
    }


}
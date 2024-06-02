using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Linq;
using System.Text;
using System.Security.AccessControl;

namespace Nika1337.Library.Infrastructure.Logging.Audit;
public static class LoggingHelper
{
    public static void LogModifiedEntities(
        ChangeTracker changeTracker,
        string userId,
        DbSet<AuditLog> auditLogs)
    {
        var modifiedEntities = changeTracker.Entries()
            .Where(e => e.State == EntityState.Added
            || e.State == EntityState.Modified
            || e.State == EntityState.Deleted)
            .ToList();

        foreach (var modifiedEntity in modifiedEntities)
        {
            var keyParts =
                modifiedEntity
                .Metadata
                .FindPrimaryKey()!
                .Properties
                .Select(p => modifiedEntity!.Property(p.Name).CurrentValue);

            var pk = string.Join(", ", keyParts);

            var auditLog = new AuditLog
            {
                EntityName = modifiedEntity!.Entity.GetType().Name,
                ModifiedRowId = pk,
                Action = modifiedEntity.State.ToString(),
                Timestamp = DateTime.UtcNow,
                Changes = GetChanges(modifiedEntity),
                UserId = userId,
            };

            auditLogs.Add(auditLog);
        }
    }
    private static string GetChanges(EntityEntry entity)
    {
        var changes = new StringBuilder();

        foreach (var property in entity.OriginalValues.Properties)
        {
            var originalValue = entity.OriginalValues[property];
            var currentValue = entity.CurrentValues[property];

            if (!Equals(originalValue, currentValue))
            {
                changes.AppendLine($"{property.Name}: From '{originalValue}' to '{currentValue}'");
            }
        }

        return changes.ToString();
    }
}

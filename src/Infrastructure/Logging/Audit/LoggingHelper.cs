using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Domain.Entities;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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

            string entityName = GetMeaningfulEntityName(modifiedEntity);

            var auditLog = new AuditLog
            {
                EntityName = entityName,
                ModifiedRowId = pk,
                Action = modifiedEntity.State.ToString(),
                Timestamp = DateTime.Now,
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

    private static string GetMeaningfulEntityName(EntityEntry entity)
    {
        if (entity.Metadata.ClrType == typeof(Dictionary<string, object>))
        {
            return entity.Metadata.Name;
        }

        return entity.Entity.GetType().Name;
    }
}

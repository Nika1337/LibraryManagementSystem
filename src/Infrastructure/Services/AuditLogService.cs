using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class AuditLogService : IAuditLogService
{
    private readonly LibraryContext _libraryContext;
    private readonly IdentityContext _identityContext;

    public AuditLogService(LibraryContext libraryContext, IdentityContext identityContext)
    {
        _libraryContext = libraryContext;
        _identityContext = identityContext;
    }

    public async Task<PagedList<AuditLog>> GetPagedAuditLogsAsync(AuditLogPagedRequest request)
    {
        var logQueryables = GetLogsQueryables(request.ApplicationNames);

        var tasks = logQueryables.Select(async kvp =>
        {
            var logs = await kvp.Value
                .SearchAndFilter(request)
                .ToListAsync();

            foreach (var log in logs)
            {
                log.ApplicationName = kvp.Key;
            }

            return logs;
        });

        var combinedLogs = (await Task.WhenAll(tasks)).SelectMany(logs => logs);

        var sortedAndPagedLogs = combinedLogs
            .Sort(request)
            .Page(request);

        return sortedAndPagedLogs;
    }

    private Dictionary<string, IQueryable<AuditLog>> GetLogsQueryables(string[]? applications)
    {
        var logsList = new Dictionary<string, IQueryable<AuditLog>>();
        var includeAllApplications = applications == null || applications.Length == 0;
        var applicationsSet = applications?.ToHashSet() ?? [];

        if (includeAllApplications || applicationsSet.Contains("Library"))
        {
            logsList.Add("Library", _libraryContext.AuditLogs);
        }
        if (includeAllApplications || applicationsSet.Contains("Identity"))
        {
            logsList.Add("Identity", _identityContext.AuditLogs);
        }

        return logsList;
    }
}

internal static class AuditLogServiceExtensions
{
    internal static IQueryable<AuditLog> SearchAndFilter(this IQueryable<AuditLog> logs, AuditLogPagedRequest request)
    {
        return logs
            .Search(request)
            .Filter(request);
    }

    internal static IQueryable<AuditLog> Search(this IQueryable<AuditLog> logs, AuditLogPagedRequest request)
    {
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            logs = logs.Where(log =>
                log.Changes.Contains(request.SearchTerm) ||
                log.UserId.Contains(request.SearchTerm) ||
                log.EntityName.Contains(request.SearchTerm) ||
                log.ModifiedRowId.Contains(request.SearchTerm));
        }

        return logs;
    }

    internal static IQueryable<AuditLog> Filter(this IQueryable<AuditLog> logs, AuditLogPagedRequest request)
    {
        if (request.StartTime != null)
        {
            logs = logs.Where(log => log.Timestamp >= request.StartTime);
        }

        if (request.EndTime != null)
        {
            logs = logs.Where(log => log.Timestamp <= request.EndTime);
        }

        if (request.Actions != null && request.Actions.Length != 0)
        {
            logs = logs.Where(log => request.Actions.Contains(log.Action));
        }

        return logs;
    }

    internal static IEnumerable<AuditLog> Sort(this IEnumerable<AuditLog> logs, PagedRequest<AuditLog> request)
    {
        if (request.OrderBy != null)
        {
            logs = request.IsDescending
                ? logs.OrderByDescending(request.OrderBy.Compile())
                : logs.OrderBy(request.OrderBy.Compile());
        }

        return logs;
    }

    internal static PagedList<AuditLog> Page(this IEnumerable<AuditLog> logs, PagedRequest<AuditLog> request)
    {
        return PagedList<AuditLog>.ToPagedList(logs, request.PageNumber, request.PageSize);
    }
}

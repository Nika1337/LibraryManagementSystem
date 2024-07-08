using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using Nika1337.Library.Infrastructure.Data;
using Nika1337.Library.Infrastructure.Identity;
using System;
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
        var libraryLogs =
            _libraryContext.AuditLogs.Select(log => log.UpdateApplicationName("Library"));

        var identityLogs =
            _identityContext.AuditLogs.Select(log => log.UpdateApplicationName("Identity"));


        var combinedLogs = libraryLogs.Concat(identityLogs);


        var finalLogs = combinedLogs
            .Search(request)
            .Filter(request)
            .Sort(request)
            .Page(request);

        return await finalLogs;
    }

}

internal static class AuditLogServiceExtensions
{
    internal static IQueryable<AuditLog> Search(this IQueryable<AuditLog> logs, AuditLogPagedRequest request)
    {
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            logs = logs.Where(log =>
                log.Changes.Contains(request.SearchTerm)
                || log.UserId.Contains(request.SearchTerm)
                || log.EntityName.Contains(request.SearchTerm)
                || log.ModifiedRowId.Contains(request.SearchTerm));
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

        if (request.Actions != null)
        {
            logs = logs.Where(log => request.Actions.Contains(log.Action));
        }

        if (request.ApplicationNames != null)
        {
            logs = logs.Where(log => request.ApplicationNames.Contains(log.ApplicationName));
        }

        return logs;
    }

    internal static IQueryable<AuditLog> Sort(this IQueryable<AuditLog> logs, PagedRequest<AuditLog> request)
    {
        if (request.OrderBy != null)
        {
            logs = request.IsDescending
                ? logs.OrderByDescending(request.OrderBy)
                : logs.OrderBy(request.OrderBy);
        }
        return logs;
    }

    internal static async Task<PagedList<AuditLog>> Page(this IQueryable<AuditLog> logs, PagedRequest<AuditLog> request)
    {
        var totalCount = logs.Count();

        logs = logs
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var logsList = await logs.ToListAsync();

        var result = new PagedList<AuditLog>(logsList, totalCount, request.PageNumber, request.PageSize);

        return result;
    }

}
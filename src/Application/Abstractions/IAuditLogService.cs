﻿using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;
public interface IAuditLogService
{
    Task<PagedList<AuditLog>> GetPagedAuditLogs(PagedRequest<AuditLog> request);
}

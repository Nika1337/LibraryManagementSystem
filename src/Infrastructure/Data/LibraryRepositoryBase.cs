using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Data;

public class LibraryRepositoryBase<T>(DbContext dbContext) : RepositoryBase<T>(dbContext) where T : BaseModel
{
    public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.CreationDate = DateTime.UtcNow;
        entity.LastUpdatedDate = DateTime.UtcNow;
        return await base.AddAsync(entity, cancellationToken);
    }

    public override async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            entity.CreationDate = DateTime.UtcNow;
            entity.LastUpdatedDate = DateTime.UtcNow;
        }
        return await base.AddRangeAsync(entities, cancellationToken);
    }

    public override async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.LastUpdatedDate = DateTime.UtcNow;
        await base.UpdateAsync(entity, cancellationToken);
    }
    public override async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            entity.LastUpdatedDate = DateTime.UtcNow;
        }
        await base.UpdateRangeAsync(entities, cancellationToken);
    }

    public override async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        entity.DeletedDate = DateTime.UtcNow;
        await UpdateAsync(entity, cancellationToken);
    }

    public override async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            entity.DeletedDate = DateTime.UtcNow;
        }
        await UpdateRangeAsync(entities, cancellationToken);
    }
    public override async Task DeleteRangeAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        var entities = await ListAsync(specification, cancellationToken);
        await DeleteRangeAsync(entities, cancellationToken);
    }

    public override async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await ListAsync(new NonDeletedEntities<T>(), cancellationToken);
    }

    public override async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await CountAsync(new NonDeletedEntities<T>(), cancellationToken);
    }

    public override async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await AnyAsync(new NonDeletedEntities<T>(), cancellationToken);
    }

}

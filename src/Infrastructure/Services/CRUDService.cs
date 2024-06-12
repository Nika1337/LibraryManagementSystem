using AutoMapper;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.ApplicationCore.Abstractions;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

public abstract class CRUDService<T> : ICRUDService<T> where T : BaseModel
{
    protected readonly IRepository<T> _repository;
    private readonly IMapper _mapper;

    public CRUDService(
        IRepository<T> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TReturn>> GetAllAsync<TReturn>()
    {
        var entities = await _repository.ListAsync();

        var response = _mapper.Map<IEnumerable<TReturn>>(entities);

        return response;
    }

    public async Task<TReturn> GetAsync<TReturn>(int id)
    {
        var entity = await GetEntityAsync(id);

        var response = _mapper.Map<TReturn>(entity);

        return response;
    }

    public async Task CreateAsync<TRequest>(TRequest request, Expression<Func<TRequest, string>> nameSelector)
    {
        var name = nameSelector.Compile()(request);

        await ThrowIfNameExistsAsync(name);

        var entity = _mapper.Map<T>(request);

        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync<TRequest>(
        TRequest request,
        Expression<Func<TRequest, int>> IdSelector,
        Expression<Func<TRequest, string>> nameSelector)
    {
        var id = IdSelector.Compile()(request);
        var name = nameSelector.Compile()(request);

        await ThrowIfEntityWithGivenNameHasDifferentId(name, id);

        var entity = await GetEntityAsync(id);

        _mapper.Map(request, entity);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetEntityAsync(id);

        entity.Delete();

        await _repository.UpdateAsync(entity);
    }

    public async Task RenewAsync(int id)
    {
        var entity = await GetEntityAsync(id);

        entity.Renew();

        await _repository.UpdateAsync(entity);
    }

    private async Task<T> GetEntityAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException<T>(id);

        return entity;
    }
    protected abstract Task ThrowIfNameExistsAsync(string name);
    protected abstract Task ThrowIfEntityWithGivenNameHasDifferentId(string name, int id);
}

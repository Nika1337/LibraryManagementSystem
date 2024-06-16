using Ardalis.Specification;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Domain.Abstractions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Exceptions;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal abstract class BaseModelService<T> : IBaseModelService where T : BaseModel
{
    protected readonly IRepository<T> _repository;

    public BaseModelService(IRepository<T> repository)
    {
        _repository = repository;
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

    protected async Task<T> GetEntityAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException<T>(id);

        return entity;
    }
}

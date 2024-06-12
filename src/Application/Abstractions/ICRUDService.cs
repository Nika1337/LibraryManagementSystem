using Nika1337.Library.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface ICRUDService<T> where T : BaseModel
{
    protected Task<IEnumerable<TReturn>> GetAllAsync<TReturn>();
    protected Task<TReturn> GetAsync<TReturn>(int id);
    protected Task CreateAsync<TRequest>(TRequest request, Expression<Func<TRequest, string>> nameSelector);
    protected Task DeleteAsync(int id);
    protected Task RenewAsync(int id);
}

using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IBaseModelService
{
    Task DeleteAsync(int id);
    Task RenewAsync(int id);
}

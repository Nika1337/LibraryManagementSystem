
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface ILanguageService : IBaseModelService
{
    Task<IEnumerable<LanguageResponse>> GetLanguagesAsync();
    Task<LanguageResponse> GetLanguageAsync(int id);
    Task CreateLanguageAsync(LanguageCreateRequest request);
    Task UpdateLanguageAsync(LanguageUpdateRequest request);
}


using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface ILanguageService : IBaseModelService
{
    Task<PagedList<LanguageResponse>> GetPagedLanguagesAsync(BaseModelPagedRequest<Language> request);
    Task<IEnumerable<LanguagePreviewResponse>> GetActiveLanguagePreviewsAsync();
    Task<LanguageResponse> GetLanguageAsync(int id);
    Task CreateLanguageAsync(LanguageCreateRequest request);
    Task UpdateLanguageAsync(LanguageUpdateRequest request);
}

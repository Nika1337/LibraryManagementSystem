using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Languages.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class LanguageMappingProfile : Profile
{
    public LanguageMappingProfile()
    {
        CreateMap<LanguageCreateRequest, Language>();

        CreateMap<LanguageUpdateRequest, Language>();

        CreateMap<LanguageResult, LanguagePreviewResponse>();

        CreateMap<LanguageDetailedResult, LanguageDetailedResponse>();

        CreateMap<Language, PrimitiveResponse>();
    }
}

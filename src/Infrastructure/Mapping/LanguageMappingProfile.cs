using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class LanguageMappingProfile : Profile
{
    public LanguageMappingProfile()
    {
        CreateMap<LanguageCreateRequest, Language>();

        CreateMap<LanguageUpdateRequest, Language>();

        CreateMap<Language, LanguageResponse>();

        CreateMap<Language, LanguagePreviewResponse>();
    }
}

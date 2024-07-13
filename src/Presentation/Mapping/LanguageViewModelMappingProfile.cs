using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Languages;
using Nika1337.Library.Presentation.Models.Languages;
namespace Nika1337.Library.Presentation.Mapping;

public class LanguageViewModelMappingProfile : Profile
{
    public LanguageViewModelMappingProfile()
    {
        CreateMap<LanguageDetailedViewModel, LanguageUpdateRequest>();

        CreateMap<LanguageResponse, LanguageDetailedViewModel>();

        CreateMap<LanguageResponse, LanguageViewModel>();

        CreateMap<LanguageCreateViewModel, LanguageCreateRequest>();
    }
}

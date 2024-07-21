using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;
using Nika1337.Library.Presentation.Models.Checkouts;
namespace Nika1337.Library.Presentation.Mapping;

public class CheckoutViewModelMappingProfile : Profile
{
    public CheckoutViewModelMappingProfile()
    {
        CreateMap<CheckoutDetailedViewModel, CheckoutCloseRequest>();

        CreateMap<CheckoutDetailedResponse, CheckoutDetailedViewModel>();

        CreateMap<CheckoutPreviewResponse, CheckoutPreviewViewModel>();

        CreateMap<CheckoutCreateViewModel, CheckoutCreateRequest>();
    }
}

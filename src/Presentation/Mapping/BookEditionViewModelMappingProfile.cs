using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;
using Nika1337.Library.Presentation.Models.BookEditions;

namespace Nika1337.Library.Presentation.Mapping;

public class BookEditionViewModelMappingProfile : Profile
{
    public BookEditionViewModelMappingProfile()
    {
        CreateMap<BookEditionDetailedViewModel, BookEditionUpdateRequest>();

        CreateMap<BookEditionDetailedResponse, BookEditionDetailedViewModel>();

        CreateMap<BookEditionPreviewResponse, BookEditionPreviewViewModel>();

        CreateMap<BookEditionCopiesAuditEntryResponse, BookEditionCopiesAuditEntryViewModel>();

        CreateMap<BookEditionCreateViewModel, BookEditionCreateRequest>();
    }
}

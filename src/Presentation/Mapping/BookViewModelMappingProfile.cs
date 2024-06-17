using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Presentation.Models.Books;

namespace Nika1337.Library.Presentation.Mapping;

public class BookViewModelMappingProfile : Profile
{
    public BookViewModelMappingProfile()
    {
        CreateMap<BookPreviewResponse, BookViewModel>();

        CreateMap<BookCreateViewModel, BookCreateRequest>();

        CreateMap<BookDetailedResponse, BookDetailViewModel>();

        CreateMap<BookDetailViewModel, BookUpdateRequest>();
    }
}

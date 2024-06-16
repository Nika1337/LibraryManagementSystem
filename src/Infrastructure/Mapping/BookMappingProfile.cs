
using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;

namespace Nika1337.Library.Infrastructure.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookCreateRequest, Book>()
            .ForMember(b => b.OriginalLanguage, opts => opts.Ignore())
            .ForMember(b => b.Genres, opts => opts.Ignore())
            .ForMember(b => b.Authors, opts => opts.Ignore())
            .ForMember(b => b.Editions, opts => opts.Ignore());


        CreateMap<BookUpdateRequest, Book>()
            .ForMember(b => b.OriginalLanguage, opts => opts.Ignore())
            .ForMember(b => b.Genres, opts => opts.Ignore())
            .ForMember(b => b.Authors, opts => opts.Ignore())
            .ForMember(b => b.Editions, opts => opts.Ignore());


        CreateMap<Book, BookDetailedResponse>();

        CreateMap<Book, BookPreviewResponse>()
            .ForMember(bpr => bpr.EditionsCount, opts => opts.MapFrom(b => b.Editions.Count));
    }
}


using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Books;
using Nika1337.Library.Domain.Entities;
using System.Linq;

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


        CreateMap<Book, BookDetailedResponse>()
            .ForMember(bdr => bdr.GenreIds, opts => opts.MapFrom(b => b.Genres.Select(genre => genre.Id)))
            .ForMember(bdr => bdr.AuthorIds, opts => opts.MapFrom(b => b.Authors.Select(author => author.Id)))
            .ForMember(bdr => bdr.OriginalLanguageId, opts => opts.MapFrom(b => b.OriginalLanguage.Id));

        CreateMap<Book, BookPreviewResponse>()
            .ForMember(bpr => bpr.EditionsCount, opts => opts.MapFrom(b => b.Editions.Count))
            .ForMember(bpr => bpr.OriginalLanguageName, opts => opts.MapFrom(b => b.OriginalLanguage.Name))
            .ForMember(bpr => bpr.AuthorNames, opts => opts.MapFrom(b => b.Authors.Select(author => author.Name).ToArray()));
    }
}

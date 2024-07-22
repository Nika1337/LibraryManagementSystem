

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.BookEditions;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.BookEditions.Results;

namespace Nika1337.Library.Infrastructure.Mapping;

public class BookEditionMappingProfile : Profile
{
    public BookEditionMappingProfile()
    {
        CreateMap<BookEditionCreateRequest, BookEdition>()
            .ForMember(be => be.Book, opts => opts.Ignore())
            .ForMember(be => be.Publisher, opts => opts.Ignore())
            .ForMember(be => be.Language, opts => opts.Ignore())
            .ForMember(be => be.Room, opts => opts.Ignore())
            .ForMember(be => be.Copies, opts => opts.Ignore());

        CreateMap<BookEditionUpdateRequest, BookEdition>()
            .ForMember(be => be.Book, opts => opts.Ignore())
            .ForMember(be => be.Publisher, opts => opts.Ignore())
            .ForMember(be => be.Language, opts => opts.Ignore())
            .ForMember(be => be.Room, opts => opts.Ignore())
            .ForMember(be => be.Copies, opts => opts.Ignore());

        CreateMap<BookEditionByIdResult, BookEditionDetailedResponse>();

        CreateMap<BookEditionResult, BookEditionPreviewResponse>();

        CreateMap<AvaliableBookEditionResult, PrimitiveResponse>()
            .ForMember(
                pr => pr.Name,
                opts => opts.MapFrom(aber => $"Published by {aber.PublisherName} in {aber.LanguageName} has {aber.AvaliableCopiesCount} copies avaliable")
            );
    }
}

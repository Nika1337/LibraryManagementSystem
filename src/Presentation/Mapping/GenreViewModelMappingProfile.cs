﻿using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Genres;
using Nika1337.Library.Presentation.Models.Genres;

namespace Nika1337.Library.Presentation.Mapping;

public class GenreViewModelMappingProfile : Profile
{
    public GenreViewModelMappingProfile()
    {
        CreateMap<GenreDetailViewModel, GenreUpdateRequest>();

        CreateMap<GenrePreviewResponse, GenrePreviewViewModel>();

        CreateMap<GenreDetailedResponse, GenreDetailViewModel>();

        CreateMap<GenreCreateViewModel, GenreCreateRequest>();
    }
}

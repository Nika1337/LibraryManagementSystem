using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.Specifications.Checkouts.Results;
using System;

namespace Nika1337.Library.Infrastructure.Mapping;

public class CheckoutMappingProfile : Profile
{
    public CheckoutMappingProfile()
    {
        CreateMap<CheckoutCreateRequest, Checkout>()
            .ForMember(ch => ch.CheckoutTime, opts => opts.MapFrom(ccr => DateTime.Now));

        CreateMap<CheckoutResult, CheckoutPreviewResponse>();

        CreateMap<CheckoutDetailedResult, CheckoutDetailedResponse>();
    }
}

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Domain.RequestFeatures;

namespace Nika1337.Library.Infrastructure.Mapping.RequestFeatures;

public class RequestFeaturesMappingProfile : Profile
{
    public RequestFeaturesMappingProfile()
    {
        CreateMap(typeof(BaseModelPagedRequest<>), typeof(BaseModelSpecificationParameters<>));
        CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
    }
}
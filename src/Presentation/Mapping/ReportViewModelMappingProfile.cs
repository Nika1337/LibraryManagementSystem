

using AutoMapper;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Presentation.Models.Reports;

namespace Nika1337.Library.Presentation.Mapping;

public class ReportViewModelMappingProfile : Profile
{
    public ReportViewModelMappingProfile()
    {
        CreateMap<TableResponse, ReportViewModel>();
    }
}

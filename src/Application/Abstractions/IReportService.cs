

using Nika1337.Library.Application.DataTransferObjects.Reports;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IReportService
{
    public Task<ReportResponse> GenerateAnnualReportAsync(AnnualReportRequest request);
}

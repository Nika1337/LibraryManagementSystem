

using Nika1337.Library.Application.DataTransferObjects.Reports;
using System.Data;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IReportDataSource
{
    public Task<TableResponse> GetAnnualReportTableAsync(AnnualReportBySubjectAndMetricRequest request);
    public Task<DataSet> GetPopularityReportDataSetAsync(AnnualReportRequest request);
}

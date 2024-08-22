

using Nika1337.Library.Application.DataTransferObjects.Export;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface IExportService
{
    public Task<byte[]> ExportToExcelAsync(ExcelExportRequest request);
}

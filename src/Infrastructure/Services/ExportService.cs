using Mailjet.Client.Resources.SMS;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Export;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class ExportService : IExportService
{
    public async Task<byte[]> ExportToExcelAsync(ExcelExportRequest request)
    {
        using var package = new ExcelPackage();

        var worksheet = package.Workbook.Worksheets.Add("Annual Report");

        // Add the column names
        for (int i = 0; i < request.ColumnNames.Length; i++)
        {
            worksheet.Cells[1, i + 1].Value = request.ColumnNames[i];
            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        // Add the content rows
        for (int i = 0; i < request.Content.Length; i++)
        {
            for (int j = 0; j < request.Content[i].Length; j++)
            {
                worksheet.Cells[i + 2, j + 1].Value = request.Content[i][j];
            }
        }

        worksheet.Cells.AutoFitColumns();

        // Return the Excel file as a byte array
        return await package.GetAsByteArrayAsync();
    }
}

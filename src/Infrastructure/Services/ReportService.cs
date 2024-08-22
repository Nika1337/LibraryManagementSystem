using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Infrastructure.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class ReportService : IReportService
{
    private readonly LibraryContext _libraryContext;

    public ReportService(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<ReportResponse> GenerateAnnualReportAsync(AnnualReportRequest request)
    {
        var procedureName = $"{request.Subject}By{request.Metric}Report";
        var yearParameter = new SqlParameter("@Year", request.Year);

        await using var command = _libraryContext.Database.GetDbConnection().CreateCommand();
        command.CommandText = procedureName;
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(yearParameter);

        await _libraryContext.Database.OpenConnectionAsync();

        await using var reader = await command.ExecuteReaderAsync();

        // Extract column names
        var columnNames = GetColumnNames(reader);

        // Extract content rows
        var content = await GetContentAsync(reader);

        return new ReportResponse
        {
            ColumnNames = columnNames,
            Content = content
        };
    }

    private static string[] GetColumnNames(DbDataReader reader)
    {
        var columnNames = new string[reader.FieldCount];
        for (int i = 0; i < reader.FieldCount; i++)
        {
            columnNames[i] = reader.GetName(i);
        }
        return columnNames;
    }

    private static async Task<string[][]> GetContentAsync(DbDataReader reader)
    {
        var content = new List<string[]>();
        while (await reader.ReadAsync())
        {
            var row = new string[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                row[i] = reader[i]?.ToString() ?? string.Empty;
            }
            content.Add(row);
        }
        return content.ToArray();
    }
}

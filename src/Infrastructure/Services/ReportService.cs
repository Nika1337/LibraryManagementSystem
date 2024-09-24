using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using Nika1337.Library.Domain.Exceptions;
using Nika1337.Library.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Services;

internal class ReportService : IReportService
{
    private readonly LibraryContext _libraryContext;


    private readonly Dictionary<string, string[]> _subjectWithMetrics = new()
    {
        { "Books", ["Popularity", "Lost Or Destroyed"] },
        { "Accounts", ["Books Taken", "Books Lost Or Destroyed", "Checkouts Completed"] },
        { "Publishers", ["Popularity"] },
        { "Genres", ["Popularity"] },
        { "Languages", ["Popularity"] },
        { "Authors", ["Popularity"] }
    };
    public IReadOnlyDictionary<string, string[]> SubjectsWithMetrics => new ReadOnlyDictionary<string, string[]>(_subjectWithMetrics);


    private readonly string[] _reportNames = ["Popularity"];
    public IReadOnlyCollection<string> ReportNames => new ReadOnlyCollection<string>(_reportNames);

    public ReportService(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<TableResponse> GetAnnualReportTableAsync(AnnualReportBySubjectAndMetricRequest request)
    {
        if(!SubjectAndMetricExist(request.Metric, request.Subject))
        {
            throw new NotFoundException("Subject not found");
        }

        var procedureName = $"{request.Subject}By{request.Metric.Replace(" ", "")}Report";
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

        return new TableResponse
        {
            ColumnNames = columnNames,
            Content = content
        };
    }

    public Task<DataSet> GetAnnualReportDataSetAsync(AnnualNamedReportRequest request)
    {


        throw new NotImplementedException();
    }




    private bool SubjectAndMetricExist(string metric, string subject)
    {
        return _subjectWithMetrics.ContainsKey(subject) && _subjectWithMetrics[subject].Contains(metric);
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
        return [.. content];
    }

}

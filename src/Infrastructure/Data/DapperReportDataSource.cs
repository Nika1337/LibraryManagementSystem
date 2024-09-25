using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.Application.Abstractions;
using Nika1337.Library.Application.DataTransferObjects.Reports;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Nika1337.Library.Infrastructure.Data;

internal class DapperReportDataSource : IReportDataSource
{
    private readonly LibraryContext _libraryContext;

    public DapperReportDataSource(LibraryContext libraryContext)
    {
        _libraryContext = libraryContext;
    }

    public async Task<TableResponse> GetAnnualReportTableAsync(AnnualReportBySubjectAndMetricRequest request)
    {
        var procedureName = $"{request.Subject}By{request.Metric.Replace(" ", "")}Report";

        using var connection = new SqlConnection(_libraryContext.Database.GetConnectionString());
        await connection.OpenAsync();

        var parameters = new DynamicParameters();
        parameters.Add("@Year", request.Year);

        var rows = await connection.QueryAsync(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        if (!rows.Any())
            return new TableResponse { ColumnNames = [], Content = [] };

        var firstRow = (IDictionary<string, object>)rows.First();
        var columnNames = firstRow.Keys.ToArray();

        return new TableResponse
        {
            ColumnNames = columnNames,
            Content = rows.Select(row => columnNames.Select(col => $"{((IDictionary<string, object>)row)[col]}").ToArray()).ToArray()
        };
    }

    public async Task<DataSet> GetPopularityReportDataSetAsync(AnnualReportRequest request)
    {
        using var connection = new SqlConnection(_libraryContext.Database.GetConnectionString());
        await connection.OpenAsync();

        var query = @"
            EXEC TopTenBooksByPopularityWithOthers @Year
            EXEC TopTenAccountsByCopiesTakenWithOthers @Year
            EXEC TopTenAuthorsByPopularityWithOthers @Year
            EXEC TopTenPublishersByPopularityWithOthers @Year
            EXEC TopTenGenresByPopularityWithOthers @Year
            EXEC TopTenLanguagesByPopularityWithOthers @Year
        ";

        var gridReader = await connection.QueryMultipleAsync(query, new { request.Year });


        var tableNames = new[] { "TopBooks", "TopAccounts", "TopAuthors", "TopPublishers", "TopGenres", "TopLanguages" };

        var popularityDataSet = await ExtractDataSet(gridReader, tableNames);

        return popularityDataSet;
    }

    private static async Task<DataSet> ExtractDataSet(GridReader gridReader, string[] tableNames)
    {
        var dataSet = new DataSet();

        foreach (var tableName in tableNames)
        {
            var records = await gridReader.ReadAsync<NameWithCount>();
            var dataTable = new DataTable(tableName);
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Count", typeof(int));

            foreach (var record in records)
            {
                dataTable.Rows.Add(record.Name, record.Count);
            }

            dataSet.Tables.Add(dataTable);
        }

        return dataSet;
    }

    private record NameWithCount(string Name, int Count);
}

using System.Globalization;
using System.Text;
using CsvHelper;
using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;

namespace OrdersReport.Infrastructure;

public sealed class CsvOrdersRepository : IOrdersRepository
{
    private const string FileName = "orders_log.csv";

    public IReadOnlyList<Order> GetAll()
    {
        var filePath = Path.Combine(AppContext.BaseDirectory, FileName);

        using var reader = new StreamReader(filePath, Encoding.UTF8);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<OrderMap>();
        return csv.GetRecords<Order>().ToList();
    }
}
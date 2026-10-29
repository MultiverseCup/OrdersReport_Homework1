using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;
using System.Globalization;
namespace OrdersReport.Presentation
{
    public class ConsoleReportWriter : IReportWriter
    {
        public void Write(IReadOnlyList<ClientOrdersSummary> report)
        {
            Console.WriteLine("client_id | orders_sum | favorite_item_name");
            foreach (var row in report)
            {
                var sum = row.OrdersSum.ToString("F2", CultureInfo.InvariantCulture);
                Console.WriteLine($"{row.ClientId} | {sum} | {row.FavoriteItemName}");
            }
        }
    }
}

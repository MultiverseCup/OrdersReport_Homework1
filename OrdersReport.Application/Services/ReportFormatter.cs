using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OrdersReport.Application.Services
{
    public class ReportFormatter : IReportFormatter
    {
        public IReadOnlyList<string> Format(IReadOnlyList<ClientOrdersSummary> report)
        {
            var lines = new List<string> { "client_id | orders_sum | favorite_item_name" };

            foreach (var row in report)
            {
                var sum = row.OrdersSum.ToString("F2", CultureInfo.InvariantCulture);
                lines.Add($"{row.ClientId}".PadRight(10) + "|" + $" {sum}".PadRight(12) + "|" + $" {row.FavoriteItemName}");
            }

            return lines;
        }
    }
}

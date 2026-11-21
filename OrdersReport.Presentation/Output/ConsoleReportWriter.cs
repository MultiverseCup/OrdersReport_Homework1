using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;
using System.Globalization;
namespace OrdersReport.Presentation.Output
{
    public class ConsoleReportWriter : IReportWriter
    {
        private readonly IReportFormatter _formatter;

        public ConsoleReportWriter(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Write(IReadOnlyList<ClientOrdersSummary> report)
        {
            foreach (var line in _formatter.Format(report))
            {
                Console.WriteLine(line);
            }
        }
    }
}

using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersReport.Presentation.Output
{
    public class FileReportWriter : IReportWriter
    {
        private const string ReportsDirectoryName = "reports";

        private readonly IReportFormatter _formatter;

        public FileReportWriter(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void Write(IReadOnlyList<ClientOrdersSummary> report)
        {
            var directory = Path.Combine(AppContext.BaseDirectory, ReportsDirectoryName);
            Directory.CreateDirectory(directory);

            var fileName = $"orders_report_{DateTime.Now:yyyyMMdd_HHmmss_fff}.txt";
            var filePath = Path.Combine(directory, fileName);

            File.WriteAllLines(filePath, _formatter.Format(report));
        }
    }
}

using OrdersReport.Domain.Entities;

namespace OrdersReport.Application.Abstractions
{
    public interface IReportFormatter
    {
        IReadOnlyList<string> Format(IReadOnlyList<ClientOrdersSummary> report);
    }
}

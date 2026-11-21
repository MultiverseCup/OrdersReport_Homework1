namespace OrdersReport.Presentation.Input
{
    public record AppArguments(ReportMode Mode, IReadOnlyCollection<long> ClientIds);
}

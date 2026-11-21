using Microsoft.Extensions.DependencyInjection;
using OrdersReport.Application.Abstractions;
using OrdersReport.Application.Services;
using OrdersReport.Application.UseCases;
using OrdersReport.Domain.Exceptions;
using OrdersReport.Infrastructure;
using OrdersReport.Presentation.Input;
using OrdersReport.Presentation.Output;


Console.OutputEncoding = System.Text.Encoding.UTF8;

var services = new ServiceCollection();
services.AddSingleton<IArgumentsParser, ArgumentsParser>();
services.AddSingleton<IOrdersRepository, CsvOrdersRepository>();
services.AddSingleton<IReportFormatter, ReportFormatter>();
services.AddKeyedSingleton<IReportWriter, ConsoleReportWriter>(ReportMode.Console);
services.AddKeyedSingleton<IReportWriter, FileReportWriter>(ReportMode.File);
services.AddTransient<GetClientsReportUseCase>();

using var provider = services.BuildServiceProvider();

try
{
    var parser = provider.GetRequiredService<IArgumentsParser>();
    var arguments = parser.Parse(args);

    var useCase = provider.GetRequiredService<GetClientsReportUseCase>();
    var writer = provider.GetRequiredKeyedService<IReportWriter>(arguments.Mode);

    var report = useCase.Execute(arguments.ClientIds);
    writer.Write(report);

    return 0;
}
catch (InvalidArgumentsException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
catch (ClientNotFoundException ex)
{
    Console.Error.WriteLine(ex.Message);
    return 1;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Ошибка обработки: {ex.Message}");
    return 1;
}
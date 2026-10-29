using Microsoft.Extensions.DependencyInjection;
using OrdersReport.Application.Abstractions;
using OrdersReport.Application.UseCases;
using OrdersReport.Domain.Exceptions;
using OrdersReport.Infrastructure;
using OrdersReport.Presentation;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Введите id клиентов через пробел: ");
var line = Console.ReadLine() ?? string.Empty;

if (!ClientIdsParser.TryParse([line], out var clientIds, out var inputError))
{
    Console.Error.WriteLine(inputError);
    return 1;
}

var services = new ServiceCollection();
services.AddSingleton<IOrdersRepository, CsvOrdersRepository>();
services.AddSingleton<IReportWriter, ConsoleReportWriter>();
services.AddTransient<GetClientsReportUseCase>();

using var provider = services.BuildServiceProvider();

try
{
    var useCase = provider.GetRequiredService<GetClientsReportUseCase>();
    var writer = provider.GetRequiredService<IReportWriter>();

    var report = useCase.Execute(clientIds);
    writer.Write(report);

    return 0;
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
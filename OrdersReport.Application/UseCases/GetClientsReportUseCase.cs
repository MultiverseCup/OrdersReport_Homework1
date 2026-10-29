using OrdersReport.Application.Abstractions;
using OrdersReport.Domain.Entities;
using OrdersReport.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Application.UseCases
{
    public class GetClientsReportUseCase
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetClientsReportUseCase(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public IReadOnlyList<ClientOrdersSummary> Execute(IReadOnlyCollection<long> clientIds)
        {
            var ordersByClient = _ordersRepository.GetAll().ToLookup(o => o.ClientId);
            var report = new List<ClientOrdersSummary>();

            foreach (var clientId in clientIds)
            {
                var orders = ordersByClient[clientId].ToList();
                if (orders.Count == 0)
                    throw new ClientNotFoundException(clientId);

                var sum = orders.Sum(o => o.ItemPrice * o.ItemQuantity);
                var favorite = orders
                    .GroupBy(o => o.ItemName)
                    .OrderByDescending(g => g.Sum(o => o.ItemQuantity))
                    .First().Key;

                report.Add(new ClientOrdersSummary(clientId, sum, favorite));
            }

            return report;
        }
    }
}

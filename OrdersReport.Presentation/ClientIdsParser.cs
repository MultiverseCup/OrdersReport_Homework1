using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Presentation
{
    public static class ClientIdsParser
    {
        public static bool TryParse(
            string[] args,
            out IReadOnlyCollection<long> clientIds,
            out string error)
        {
            clientIds = Array.Empty<long>();
            error = string.Empty;

            var parts = args
                .SelectMany(a => a.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            if (parts.Count == 0)
            {
                error = "Не переданы id клиентов. Пример запуска: OrdersReport 1010 1020";
                return false;
            }

            var ids = new List<long>();
            foreach (var part in parts)
            {
                if (!long.TryParse(part, out var id))
                {
                    error = $"Некорректный id клиента: \"{part}\". Id должен быть целым числом.";
                    return false;
                }

                ids.Add(id);
            }

            clientIds = ids.Distinct().ToList();
            return true;
        }
    }
}

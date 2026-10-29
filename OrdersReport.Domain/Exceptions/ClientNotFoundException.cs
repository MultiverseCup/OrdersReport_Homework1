using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Domain.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public long ClientId { get; }

        public ClientNotFoundException(long clientId)
            : base($"Клиент с id {clientId} не найден в записях о заказах")
        {
            ClientId = clientId;
        }
    }
}

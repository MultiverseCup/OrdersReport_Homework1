using OrdersReport.Domain.Entities;
using OrdersReport.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Application.Abstractions
{
    public interface IOrdersRepository
    {
        IReadOnlyList<Order> GetAll();
    }
}

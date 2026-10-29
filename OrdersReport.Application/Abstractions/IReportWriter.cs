using OrdersReport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Application.Abstractions
{
    public interface IReportWriter
    {
        void Write(IReadOnlyList<ClientOrdersSummary> report);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Domain.Entities
{
    public record ClientOrdersSummary(long ClientId, float OrdersSum, string FavoriteItemName);
}

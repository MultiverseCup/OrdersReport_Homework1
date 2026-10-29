using CsvHelper.Configuration;
using OrdersReport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersReport.Infrastructure
{
    public sealed class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Map(o => o.ClientId).Name("client_id");
            Map(o => o.OrderId).Name("order_id");
            Map(o => o.ItemName).Name("item_name");
            Map(o => o.ItemQuantity).Name("item_quantity");
            Map(o => o.ItemPrice).Name("item_price");
        }
    }
}

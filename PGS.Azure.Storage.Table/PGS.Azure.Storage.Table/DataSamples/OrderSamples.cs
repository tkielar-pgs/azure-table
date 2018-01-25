using System;
using System.Collections.Generic;
using PGS.Azure.Storage.Table.Model;

namespace PGS.Azure.Storage.Table.DataSamples
{
    public static class OrderSamples
    {
        public static Order DonaldsOrder => new Order
        {
            Id = Guid.Parse("6a456c57-ec65-4ea5-a167-e95d70c57016"),
            CustomerKey = CustomerSamples.DonaldDuck.RowKey,
            IsShipped = false,
            OrderedTime = new DateTime(2018, 1, 25, 14, 41, 43),
            TotalAmount = 110.24
        };

        public static Order DonaldsOrder2 => new Order
        {
            Id = Guid.Parse("ca15aaa1-d5e8-4532-ac84-cfea6f1631e5"),
            CustomerKey = CustomerSamples.DonaldDuck.RowKey,
            IsShipped = true,
            OrderedTime = new DateTime(2018, 1, 25, 16, 15, 27),
            TotalAmount = 431.19
        };

        public static Order DaffysOrder => new Order
        {
            Id = Guid.Parse("52d95705-7f96-45eb-a25a-4776ccaa1634"),
            CustomerKey = CustomerSamples.DaffyDuck.RowKey,
            IsShipped = false,
            OrderedTime = new DateTime(2017, 12, 24, 4, 5, 12),
            TotalAmount = 12.2
        };

        public static IEnumerable<Order> AllOrders
        {
            get
            {
                yield return DonaldsOrder;
                yield return DonaldsOrder2;
                yield return DaffysOrder;
            }
        }
    }
}
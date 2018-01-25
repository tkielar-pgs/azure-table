using System;
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
    }
}
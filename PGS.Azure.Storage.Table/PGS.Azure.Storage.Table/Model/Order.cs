using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace PGS.Azure.Storage.Table.Model
{
    public class Order : TableEntity
    {
        public Order() => PartitionKey = nameof(Order);

        [IgnoreProperty]
        public Guid Id
        {
            get => Guid.Parse(RowKey);
            set => RowKey = value.ToString();
        }

        public DateTime OrderedTime { get; set; }
        public double TotalAmount { get; set; }
        public bool IsShipped { get; set; }
        public Customer Customer { get; set; }
    }
}
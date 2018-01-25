using System;

namespace PGS.Azure.Storage.Table.Model
{
    public class Order
    {
        public DateTime OrderedTime { get; set; }
        public double TotalAmount { get; set; }
        public bool IsShipped { get; set; }
        public Customer Customer { get; set; }
    }
}
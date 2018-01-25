using System;

namespace PGS.Azure.Storage.Table.Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public DateTime BirthDate { get; set; }
        public double Discount { get; set; }
    }
}
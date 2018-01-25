using System;
using PGS.Azure.Storage.Table.Model;

namespace PGS.Azure.Storage.Table.DataSamples
{
    public static class CustomerSamples
    {
        public static Customer DonaldDuck => new Customer
        {
            BirthDate = new DateTime(1934, 6, 9),
            Discount = 12.5,
            FirstName = "Donald",
            LastName = "Duck",
            PhoneNo = "555-113-45"
        };
    }
}
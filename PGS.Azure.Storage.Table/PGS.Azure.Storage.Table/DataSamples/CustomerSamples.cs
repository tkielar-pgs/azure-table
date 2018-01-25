using System;
using System.Collections.Generic;
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

        public static Customer BugsBunny => new Customer
        {
            BirthDate = new DateTime(1940, 7, 27),
            Discount = 17,
            FirstName = "Bugs",
            LastName = "Bunny",
            PhoneNo = "555-1313-135"
        };

        public static Customer DaffyDuck => new Customer
        {
            BirthDate = new DateTime(1937, 4, 17),
            Discount = 7.25,
            FirstName = "Daffy",
            LastName = "Duck",
            PhoneNo = "555-871-5212"
        };

        public static IEnumerable<Customer> AllCustomers
        {
            get
            {
                yield return DonaldDuck;
                yield return BugsBunny;
                yield return DaffyDuck;
            }
        }
    }
}
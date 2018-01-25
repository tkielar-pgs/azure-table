using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace PGS.Azure.Storage.Table.Model
{
    public class Customer : TableEntity
    {
        private string _firstName;
        private string _lastName;

        public Customer() => PartitionKey = nameof(Customer);

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                SetRowKey();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                SetRowKey();
            }
        }

        public string PhoneNo { get; set; }

        public DateTime BirthDate { get; set; }

        public double Discount { get; set; }

        private void SetRowKey() => RowKey = $"{FirstName}_{LastName}";
    }
}
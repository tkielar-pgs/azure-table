using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using PGS.Azure.Storage.Table.DataSamples;

namespace PGS.Azure.Storage.Table.Examples
{
    public static class InsertExample
    {
        public static async Task InsertEntities(CloudTable table)
        {
            await table.ExecuteAsync(TableOperation.Insert(CustomerSamples.DonaldDuck));
            await table.ExecuteAsync(TableOperation.Insert(OrderSamples.DonaldsOrder));
        }
    }
}
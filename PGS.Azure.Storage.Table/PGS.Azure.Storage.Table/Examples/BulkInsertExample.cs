using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using PGS.Azure.Storage.Table.DataSamples;

namespace PGS.Azure.Storage.Table.Examples
{
    public static class BulkInsertExample
    {
        public static async Task InsertAllSamples(CloudTable table)
        {
            await BatchInsert(CustomerSamples.AllCustomers, table);
            await BatchInsert(OrderSamples.AllOrders, table);
        }

        private static Task BatchInsert(IEnumerable<ITableEntity> entities, CloudTable table)
        {
            var batch = new TableBatchOperation();

            foreach (ITableEntity entity in entities)
            {
                batch.Add(TableOperation.Insert(entity));
            }

            return table.ExecuteBatchAsync(batch);
        }
    }
}
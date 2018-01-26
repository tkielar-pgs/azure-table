using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using PGS.Azure.Storage.Table.Model;

namespace PGS.Azure.Storage.Table.Examples
{
    public static class QueryExample
    {
        public static void QueryOrdersIn2017(CloudTable table)
        {
            Console.WriteLine("QueryOrdersIn2017");

            string DateCondition(string operation, DateTime date) =>
                TableQuery.GenerateFilterConditionForDate(nameof(Order.OrderedTime), operation, new DateTimeOffset(date));

            TableQuery<Order> query = new TableQuery<Order>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(nameof(Order.PartitionKey), QueryComparisons.Equal, nameof(Order)),
                    TableOperators.And,
                    TableQuery.CombineFilters(
                        DateCondition(QueryComparisons.GreaterThanOrEqual, new DateTime(2017, 1, 1)),
                        TableOperators.And,
                        DateCondition(QueryComparisons.LessThan, new DateTime(2018, 1, 1)))
                    ));

            Console.WriteLine($"Executing query [{query.FilterString}]");
            PrintResults(table.ExecuteQuery(query));
        }

        public static void QueryOrdersIn2017Linq(CloudTable table)
        {
            Console.WriteLine("QueryOrdersIn2017Linq");

            IQueryable<Order> query = table.CreateQuery<Order>().Where(order =>
                order.PartitionKey == nameof(Order) && order.OrderedTime >= new DateTime(2017, 1, 1) && order.OrderedTime < new DateTime(2018, 1, 1));

            PrintResults(query);
        }

        public static void ExecuteAllQueries(CloudTable table)
        {
            QueryOrdersIn2017(table);
            Console.WriteLine();
            QueryOrdersIn2017Linq(table);
        }

        private static void PrintResults(IEnumerable<ITableEntity> queryResult)
        {
            const int columnWidth = 25;

            var tableEntities = queryResult as ITableEntity[] ?? queryResult.ToArray();
            Console.WriteLine($"Query returned {tableEntities.Length} results");
            if (tableEntities.Length == 0)
            {                
                return;
            }

            Console.WriteLine(string.Concat(tableEntities[0].WriteEntity(null).Select(property => property.Key.PadRight(columnWidth))));
            foreach (IDictionary<string, EntityProperty> properties in tableEntities.Select(entity => entity.WriteEntity(null)))
            {
                Console.WriteLine(string.Concat(properties.Values.Select(val => val.PropertyAsObject.ToString().PadRight(columnWidth))));
            }
        }
    }
}
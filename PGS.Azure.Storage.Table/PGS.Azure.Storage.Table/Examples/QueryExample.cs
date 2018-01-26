using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace PGS.Azure.Storage.Table.Examples
{
    public static class QueryExample
    {
        public static void ExecuteAllQueries(CloudTable table)
        {
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
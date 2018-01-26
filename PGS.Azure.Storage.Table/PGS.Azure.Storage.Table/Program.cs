using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using PGS.Azure.Storage.Table.Configuration;
using PGS.Azure.Storage.Table.Examples;

namespace PGS.Azure.Storage.Table
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageAccountOptions storageAccountOptions = ParseStorageAccountOptions();
            CloudTable tableReference = GetTableReferenceAsync(storageAccountOptions).GetAwaiter().GetResult();

            try
            {
//                InsertExample.InsertEntities(tableReference).GetAwaiter().GetResult();
                BulkInsertExample.InsertAllSamples(tableReference).GetAwaiter().GetResult();
                QueryExample.ExecuteAllQueries(tableReference);
            }
            catch (StorageException e)
            {
                Console.Error.WriteLine(e.RequestInformation.ExtendedErrorInformation.ErrorMessage);
                throw;
            }
            finally
            {
                Console.WriteLine("Done.");
                Console.ReadKey();
                tableReference.DeleteIfExistsAsync().GetAwaiter().GetResult();
            }
        }

        private static async Task<CloudTable> GetTableReferenceAsync(StorageAccountOptions storageAccountOptions)
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountOptions.Name, storageAccountOptions.Key), true);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            string tableName = $"{storageAccountOptions.TableName}{new Random().Next()}";
            CloudTable tableReference = tableClient.GetTableReference(tableName);
            await tableReference.CreateIfNotExistsAsync();

            Console.WriteLine($"Using table '{tableName}'");

            return tableReference;
        }

        private static StorageAccountOptions ParseStorageAccountOptions()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();

            var storageAccountOptions = new StorageAccountOptions();
            configuration.Bind("StorageAccount", storageAccountOptions);
            return storageAccountOptions;
        }
    }
}

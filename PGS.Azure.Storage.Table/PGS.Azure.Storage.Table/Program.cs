using System.IO;
using Microsoft.Extensions.Configuration;
using PGS.Azure.Storage.Table.Configuration;

namespace PGS.Azure.Storage.Table
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageAccountOptions storageAccountOptions = ParseStorageAccountOptions();
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

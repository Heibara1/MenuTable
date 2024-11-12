using Microsoft.Extensions.Configuration;
using Azure.Data.Tables;

public class AzureTableService
{
    private readonly string _connectionString;

    // Constructor som henter forbindelsesstrengen fra appsettings.json
    public AzureTableService(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("AzureStorageConnectionString");
    }

    // Metode til at tilføje et MenuItem til Azure Table Storage
    public async Task AddItemToTableAsync(MenuTable menuItem)
    {
        var serviceClient = new TableServiceClient(_connectionString);
        var tableClient = serviceClient.GetTableClient("KantineMenu");

        // Brug MenuItem direkte, som implementerer ITableEntity
        await tableClient.AddEntityAsync(menuItem);
    }
}

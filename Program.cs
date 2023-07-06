using Microsoft.Azure.Cosmos;
using Azure.Identity;


string cosmosEndpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");
if (String.IsNullOrEmpty(cosmosEndpoint))
{
    throw new ArgumentNullException("cosmosEndpoint", "Must provide a storage account name");
}

Console.WriteLine("\n###  Cosmos DB Demo  ####\n");

using CosmosClient cosmosClient = new(
    accountEndpoint: cosmosEndpoint,
    tokenCredential: new DefaultAzureCredential()
);
Console.WriteLine($"Connected to {cosmosClient.Endpoint}\n");

// Create a DB
string dbName = $"DummyDB_{Guid.NewGuid().ToString().Substring(0, 8)}";
Console.Write($"\n#### Press any key to create new DB {dbName}");
Console.ReadLine();
Database db = await cosmosClient.CreateDatabaseAsync(dbName);

// Create a container
// string containerName = $"DummyContainer_{Guid.NewGuid().ToString().Substring(0, 8)}";
// Console.Write($"\n#### Press any key to create new container {containerName}");
// Console.ReadLine();
// Container container = await db.CreateContainerAsync(containerName);

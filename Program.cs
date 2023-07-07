using Microsoft.Azure.Cosmos;
using Azure.Identity;


var cosmosEndpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT");
var cosmosDB = Environment.GetEnvironmentVariable("COSMOS_DB");
var cosmosDBContainer = Environment.GetEnvironmentVariable("COSMOS_CONTAINER");
if (String.IsNullOrEmpty(cosmosEndpoint) || String.IsNullOrEmpty(cosmosDB) || String.IsNullOrEmpty(cosmosDBContainer))
{
    throw new ArgumentNullException("Missing expected env. variables!");
}

Console.WriteLine("\n###  Cosmos DB Demo  ####\n");

using CosmosClient cosmosClient = new(
    accountEndpoint: cosmosEndpoint,
    tokenCredential: new DefaultAzureCredential()
);
Console.WriteLine($"Connected to {cosmosClient.Endpoint}\n");

// Get reference to database
Console.Write($"\n#### Press any key to get reference to DB {cosmosDB}");
Console.ReadLine();
Database database = cosmosClient.GetDatabase(cosmosDB);
Console.WriteLine($"Got reference to DB: {database.Id}");

// Get reference to container
Console.Write($"\n#### Press any key to get reference to Container {cosmosDBContainer}");
Console.ReadLine();
Container container = database.GetContainer(cosmosDBContainer);
Console.WriteLine($"Got reference to container: {container.Id}");


// Create new object and upsert (create or replace) to container
Product newItem = new(
    id: Guid.NewGuid().ToString(),
    categoryId: Guid.NewGuid().ToString(),
    categoryName: "gear-surf-surfboards",
    name: "Yamba Surfboard",
    quantity: 12,
    sale: false
);

Product createdItem = await container.CreateItemAsync<Product>(
    item: newItem,
    partitionKey: new PartitionKey(newItem.categoryId)
);

Console.WriteLine($"Created item:\t{createdItem.id}\t[{createdItem.categoryName}]");

public record Product(
    string id,
    string categoryId,
    string categoryName,
    string name,
    int quantity,
    bool sale
);

﻿using Microsoft.Azure.Cosmos;
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


// Create new animal object and upsert (create or replace) to container
Animal animal = new(
    id: Guid.NewGuid().ToString(),
    name: "Lion",
    region: "Africa"
);

Animal createdAnimal = await container.CreateItemAsync<Animal>(
    item: animal,
    partitionKey: new PartitionKey(animal.region)
);

Console.WriteLine($"Created item:\t{createdAnimal.id}\t[{createdAnimal.name}]");

public record Animal(
    string id,
    string name,
    string region
);

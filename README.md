# Azure Cosmos DB

Resources used for teaching lesson about Azure Cosmos DB using the .

## Setup

[Quickstart: Azure Cosmos DB for NoSQL client library for .NET](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-dotnet?tabs=azure-portal%2Cwindows%2Cpasswordless%2Csign-in-azure-cli)

You need:
* A Cosmos DB NoSQL account in your Azure subscription
* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (.NET 7.0 as of July 23)
* [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/) or [PowerShell](https://learn.microsoft.com/en-us/powershell/azure/?view=azps-10.1.0)

Create the following environment variables:
```
COSMOS_ENDPOINT = "<cosmos-account-URI>"
COSMOS_KEY = "<cosmos-account-PRIMARY-KEY>"
```

Values can be found in the Azure portal, in your Cosmos DB NoSQL account, under _Keys (URI and PRIMARY KEY respectivly)_.
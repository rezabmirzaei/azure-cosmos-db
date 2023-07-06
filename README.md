# Azure Cosmos DB

Resources used for teaching lesson about Azure Cosmos DB using the .

## Setup

[Quickstart: Azure Cosmos DB for NoSQL client library for .NET](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-dotnet?tabs=azure-portal%2Cwindows%2Cpasswordless%2Csign-in-azure-cli)

You need:
* A Cosmos DB NoSQL account in your Azure subscription
* [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (.NET 7.0 as of July 23)
* [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/) or [PowerShell](https://learn.microsoft.com/en-us/powershell/azure/?view=azps-10.1.0)
* __Heads up!__ Must have the [necessary roles to manage DB resources](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/quickstart-dotnet?tabs=azure-portal%2Cwindows%2Cpasswordless%2Csign-in-azure-cli#create-the-custom-role)

You need the "Cosmos DB Built-in Data Contributor", see [details here](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-setup-rbac). Try this:

```
az cosmosdb sql role assignment create --account-name <COSMOS_ACCOUNT_NAME> --resource-group <RG_NAME> --scope "/" --principal-id <PRINCIPAL_ID> --role-definition-id /subscriptions/<SUBSCRIPTION_ID>/resourceGroups/comsos-db-rg/providers/Microsoft.DocumentDB/databaseAccounts/comos-db-no-sql/sqlRoleDefinitions/00000000-0000-0000-0000-000000000002
```

The provided .NET console app was created and configured as such:
* ``dotnet new console``
* ``dotnet add package Microsoft.Azure.Cosmos``
* ``dotnet add package Azure.Identity``

Create the following environment variables:
```
COSMOS_ENDPOINT = "<cosmos-account-URI>"
COSMOS_KEY = "<cosmos-account-PRIMARY-KEY>"
```

Values can be found in the Azure portal, in your Cosmos DB NoSQL account, under _Keys (URI and PRIMARY KEY respectivly)_.
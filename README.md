# swa-authentication

Demonstration of authentication options in Azure Static Web Apps.

The authentication and authorisation code is in the "StaticWebAppAuthentication" folder.

In the root folder there is a [Client to Claims Principle](./StaticWebAppAuthentication/ClientPrincipleToClaimsPrinciple.cs) adapter. This is used by both the Blazor and Azure Functions project.

In the [Client](./Client/) and [API](./API) folders there is code specific to Blazor and Http Function to retrieve the ClientPrinciple object from each.

For Blazor WebAssembly application there is a call made to the `/.auth/me` endpoint to retrieve the ClientPrinciple, for the Azure Function this is retrieved from the `x-ms-client-principal` header.

## Getting started

First, make sure that the `local.settings.json` file exists in the `./api` folder (this is not checked into the repo in case of credentials being stored there)

If not create it copy the following settings

``` json
{
  "IsEncrypted": false,
  "Values": {
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

Install the [Static Web App CLI](https://github.com/Azure/static-web-apps-cli)
Ensure that [.NET 6 SDK is installed](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Run the following command in the root of the repo:

``` ps
swa start
```

Open the URL given by the SWA CLI

The repo can be seen in action [here](https://swa-auth.stacy-clouds.dev/)

## Credits

Blazor integration based on [Anthony Chu Authentication Provider](https://github.com/anthonychu/blazor-auth-static-web-apps)

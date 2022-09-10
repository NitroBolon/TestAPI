# TestAPI
Simple solution for testing purposes. With identity management (basic IdentityServer), .NET 6 Web API and maybe Vue.js interface in the future.

# Requirements
1. SQL Server Express on your local env
2. .NET 6 Runtime

# Usage
1. Download and instal SQL Server Management Studio
2. Download, install and configure local SQL Server with SQL Express
3. Provide connection string to DB in appsettings files
4. Go to each API project (except IdentityAPI) and run EF Core migrations to update database
4. Run IdentityServer, there is also simple console app retrieving tokens (integration with external identity provider, e.g. Google will happen in the future)
5. Use API with Bearer auth token

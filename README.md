# TestAPI Solution aka taskr app
Simple solution for testing purposes. It's meant to become simple development framework with example app - taskr. With identity management (basic IdentityServer from Duende), .NET 6 API and some services for content management. Client app built with Vue 3 on TypeScript.

# Requirements
1. SQL Server Express on your local env
2. .NET 6 Runtime
3. Node.js 14.x (currently using 14.18.1, use nvm to manage versions) with compatible npm

# Usage
1. Download and install SQL Server Management Studio
2. Download, install and configure local SQL Server with SQL Express
3. Provide connection string to DB in appsettings files
4. Go to each API project (except IdentityAPI) and run EF Core migrations to update database
4. Run IdentityServer, there is also simple console app retrieving tokens (integration with external identity provider, e.g. Google will happen in the future)
5. Use API with Bearer auth token

Currently taskr (services too tbh) is configured to work without logging in, when all issues will be resolved you'll need to register and use some test accounts.

# Launch configuration
1. taskr Vue App - https://localhost:5002
2. taskr API App - https://localhost:5003
3. TasksAPI - https://localhost:6010
4. UsersAPI - https://localhost:6020
5. TenantsAPI - https://localhost:6030
6. IdentityAPI - https://localhost:6040
7. LicensesAPI - https://localhost:6050
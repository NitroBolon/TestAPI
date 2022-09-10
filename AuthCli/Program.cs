// See https://aka.ms/new-console-template for more information
// Retrieve UsersAPI token

using IdentityModel.Client;

var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    Console.ReadKey();
    return;
}

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,

    ClientId = "test.usersapi",
    ClientSecret = "apitestusers",
    Scope = "users.api"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    Console.ReadKey();
    return;
}

Console.WriteLine(tokenResponse.AccessToken);

Console.ReadKey();
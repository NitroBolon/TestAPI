/***    DATABASE UPDATER     ***/
/***  USING RAW SQL SCRIPTS  ***/

using DbUp;
using System.Reflection;

var connectionString =
        args.FirstOrDefault()
        ?? "Server=DESKTOP-486HBQ1\\testapi;Database=testwe-local-testapi-database;Trusted_Connection=True;";

var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;

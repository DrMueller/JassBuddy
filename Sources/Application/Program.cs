using Lamar.Microsoft.DependencyInjection;
using Mmu.JassBuddy2.Components;
using Mmu.JassBuddy2.Shell.Initialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLamar(serviceRegistry =>
{
    serviceRegistry.Scan(
        scanner =>
        {
            scanner.AssembliesFromApplicationBaseDirectory();
            scanner.LookForRegistries();
        });
});

ServiceInitialization.Initialize(builder.Services, builder.Environment);

var app = builder.Build();

AppInitialization.Initialize(app);

app.Run();
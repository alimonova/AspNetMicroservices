using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Host.CreateDefaultBuilder(args)
    .ConfigureLogging((hostingContext, loggingbuilder) =>
{
    loggingbuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    loggingbuilder.AddConsole();
    loggingbuilder.AddDebug();
});

builder.Services.AddOcelot();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();
app.Run();

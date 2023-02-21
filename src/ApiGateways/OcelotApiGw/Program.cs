using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

using var loggerFactory = LoggerFactory.Create(loggingBuilder =>
{
    loggingBuilder
        .AddConfiguration(builder.Configuration.GetSection("Logging"))
        .AddConsole()
        .AddDebug();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

builder.Services.AddOcelot()
    .AddCacheManager(settings => settings.WithDictionaryHandle());
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
await app.UseOcelot();

app.Run();


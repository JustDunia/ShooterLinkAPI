using FastEndpoints;
using Serilog;
using ShooterLink;

var seqEndpoint = Environment.GetEnvironmentVariable("SEQ_ENDPOINT") ?? "http://localhost:5341";
var seqApiKey = Environment.GetEnvironmentVariable("SEQ_API_KEY");

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(serverUrl: seqEndpoint, apiKey: seqApiKey)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.ConfigureDatabase()
        .ConfigureOptions()
        .ConfigureEndpoints()
        .ConfigureServices()
        .ConfigureOutputCache();

    var app = builder.Build();

    app.UseOutputCache();
    app.UseFastEndpoints();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
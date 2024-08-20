using FastEndpoints;
using Serilog;
using ShooterLink;

Logger.Create();

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

    app.UseDefaultExceptionHandler(useGenericReason: true, logStructuredException: true)
        .UseOutputCache()
        .UseFastEndpoints();

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
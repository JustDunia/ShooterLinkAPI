using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using ShooterLink.Data;
using ShooterLink.Utilities.ApplicationOptions;
using ShooterLink.Utilities.Emails;
using ShooterLink.Utilities.Tokens;

namespace ShooterLink;

public static class AppConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ITokenCreator, TokenCreator>();

        builder.Services.AddScoped<IEmailSender, EmailSender>();

        return builder;
    }

    public static WebApplicationBuilder ConfigureEndpoints(this WebApplicationBuilder builder)
    {
        var signingKey = builder
            .Configuration
            .GetRequiredSection(KeysOptions.Key)
            .GetValue<string>(nameof(KeysOptions.SigningKey));

        builder.Services
            .AddAuthenticationJwtBearer(s => s.SigningKey = signingKey)
            .AddAuthorization()
            .AddFastEndpoints()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder ConfigureOptions(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddOptions<KeysOptions>()
            .Bind(builder.Configuration.GetRequiredSection(KeysOptions.Key))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services
            .AddOptions<EmailProviderOptions>()
            .Bind(builder.Configuration.GetRequiredSection(EmailProviderOptions.Key))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return builder;
    }

    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }

    public static WebApplicationBuilder ConfigureOutputCache(this WebApplicationBuilder builder)
    {
        builder.Services.AddOutputCache();

        return builder;
    }
}
